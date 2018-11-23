using FeedlyServiceApi.DatabaseContext;
using FeedlyServiceApi.Models;
using FeedlyServiceApi.Models.RSS;
using FeedlyServiceApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedlyServiceApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeedsNewsController : ControllerBase
	{
		private readonly FeedDbContext _context;
		private readonly ILogger _logger;
		private IMemoryCache _memoryCache;
		private object _locker = new object();

		public FeedsNewsController(FeedDbContext context, ILogger<FeedsNewsController> logger, IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
			lock(_locker)
			{
				_context = context;
			}
			_logger = logger;
		}

		[HttpGet]
		public IActionResult Index()
		{
			_logger.LogInformation("--Feedly server start--");
			return NoContent();
		}

		[HttpPost]
		[Route("LoadData")]
		public async Task<IActionResult> LoadData()
		{
			_logger.LogInformation("Checking that current database is not empty.");
			if (!_context.Feeds.Any())
			{
				_logger.LogInformation("The database is empty.");
				_logger.LogInformation("Load data into the database.");
				await DataService.InitializeData(_context);
				_logger.LogInformation("Data loaded into the database");
			}
			_logger.LogInformation("Database is not empty!");
			return NoContent();
		}


		[HttpGet]
		[Route("GetAllFeeds")]
		public async Task<List<FeedRSS>> GetAllFeeds()
		{
			using (FeedDbContext db = _context)
			{
				_logger.LogInformation("Get all FeedsNews");
				return await _context.FeedsRSS
				.Include(feed => feed.FeedsCollections).ThenInclude(fc => fc.Collection).ToListAsync();
			}
		}

		[HttpGet]
		[Route("GetFeedsFromCollection/{collectionId}")]
		public async Task<List<FeedRSS>> GetFeedsFromCollection([FromRoute]int collectionId)
		{
			using (FeedDbContext db = _context)
			{
				_logger.LogInformation("Find a collection with id = {0}", collectionId);
				Collection collection = await db.Collections.Include(fc => fc.FeedsCollections)
						.ThenInclude(f => (FeedRSS)f.Feed)
						.ThenInclude(f => f.Items).FirstAsync(c => c.Id == collectionId);
				_logger.LogInformation("Pass feeds News to client from the collection {0}.", collection.Title);
				return collection.FeedsCollections.Select(f => (FeedRSS)f.Feed).ToList();
			}
		}

		[HttpGet]
		[Route("byOwner/{ownerName}")]
		public async Task<List<Collection>> GetCollectionsByOwner([FromRoute] string ownerName)
		{
			_logger.LogInformation("Try get collections by {0} from a memory cache.", ownerName);
			if (!_memoryCache.TryGetValue(KeysService.KeyCollectionsByOwner(ownerName), out List<Collection> collections))
			{
				_logger.LogInformation("Collections have not been received from memory cache!");
				using (FeedDbContext db = _context)
				{
					_logger.LogInformation("Load collections from database by user : {0}", ownerName);
					collections = await db.Collections.Include(c => c.FeedsCollections).ThenInclude(fc => fc.Feed)
					.Where(collection => collection.OwnerName == ownerName).ToListAsync();
					_memoryCache.Set(KeysService.KeyCollectionsByOwner(ownerName), collections, TimeSpan.FromMinutes(30));
					_logger.LogInformation("Pass the collections to user: {0}", ownerName);
					return collections;
				}
			}
			_logger.LogInformation("Collections have been received from memory cache successful!");
			_logger.LogInformation("Pass the collections to user: {0}", ownerName);
			return collections;
		}

		[HttpGet]
		[Route("GetAllNews")]
		public async Task<List<ItemRSS>> GetAllNews()
		{
			if(!_memoryCache.TryGetValue(KeysService.KeyAllItems(), out List<ItemRSS> items))
			{
				using (FeedDbContext db = _context)
				{
					items = await db.ItemsRSS.ToListAsync();
					_memoryCache.Set(KeysService.KeyAllItems(), items);
				}
			}
			return items;
		}

		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> CreateCollection(Collection collection)
		{
			_logger.LogWarning("Check Collection model");
			if (!ModelState.IsValid)
			{
				_logger.LogError("The Collection model failed!");
				return BadRequest(ModelState);
			}

			try
			{
				using (FeedDbContext db = _context)
				{
					await db.Collections.AddAsync(collection);
					_logger.LogWarning("Try to save changes");
					await db.SaveChangesAsync();

					_memoryCache.Remove(KeysService.KeyCollectionsByOwner(collection.OwnerName));
				}
			}
			catch (DbUpdateConcurrencyException ex)
			{
				_logger.LogError("Save changes failed with error {0}", ex);
				GetException(ex);
			}
			catch (Exception ex)
			{
				_logger.LogError("Save changes failed with error {0}", ex);
				GetException(ex);
			}

			return CreatedAtAction("GetCollection", new { id = collection.Id }, collection);
		}

		[HttpGet("GetFeedContent/{feedId}")]
		public async Task<List<ItemRSS>> GetFeedContent([FromRoute]int feedId)
		{
			if (!_memoryCache.TryGetValue(KeysService.KeyItems(feedId), out List<ItemRSS> items))
			{
				using (FeedDbContext db = _context)
				{
					items = await _context.FeedsRSS
						.Include(f => f.Items)
						.Where(f => f.Id == feedId)
						.SelectMany(f => f.Items).ToListAsync();
					_memoryCache.Set(KeysService.KeyItems(feedId), items, TimeSpan.FromMinutes(30));
					return items;
				}
			}

			return items;
		}

		[HttpGet("GetCollection/{id}")]
		public async Task<IActionResult> GetCollection([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			Collection collection;
			using (FeedDbContext db = _context)
			{
				collection = await db.Collections.FindAsync(id);
			}
			if (collection == null)
			{
				return NotFound();
			}

			return Ok(collection);
		}

		[HttpPut]
		[Route("AddContentToCollection")]
		public async Task<IActionResult> AddContentToCollection(FeedsCollections feedsCollections)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			using (FeedDbContext db = _context)
			{
				if (!_memoryCache.TryGetValue(KeysService.KeyCollectionByFeedsCollection(feedsCollections), out Collection collection))
				{
					collection = await db.Collections.FindAsync(feedsCollections.CollectionId);
					_memoryCache.Set(KeysService.KeyCollectionByFeedsCollection(feedsCollections), collection);
				}

				collection.FeedsCollections.Add(feedsCollections);

				try
				{
					_logger.LogWarning("Try to save changes");
					await db.SaveChangesAsync();
					_logger.LogInformation("Saving changes passed successful.");
					RemoveCollectionRelatedFromCache(collection);
				}
				catch (Exception ex)
				{
					_logger.LogError("Save changes failed with error {0}", ex);
					GetException(ex);
				}
				return Ok(collection);
			}
		}

		[HttpDelete]
		[Route("DeleteCollection/{collectionId}")]
		public async Task<IActionResult> DeleteCollection([FromRoute] int collectionId)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			using (FeedDbContext db = _context)
			{
				Collection collection = await db.Collections.FindAsync(collectionId);

				try
				{
					db.Remove(collection);
					_logger.LogWarning("Try to save changes");
					await db.SaveChangesAsync();
					_logger.LogInformation("Saving changes passed successful.");
					RemoveCollectionRelatedFromCache(collection);
				}
				catch (Exception ex)
				{
					_logger.LogError("Save changes failed with error {0}", ex);
					GetException(ex);
				}
				return Ok(collection);
			}
		}

		[HttpPost]
		[Route("DeleteContentFromCollection")]
		public async Task<IActionResult> DeleteContentFromCollection(FeedsCollections feedsCollection)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			using (FeedDbContext db = _context)
			{
				_logger.LogInformation("Loading collection");
				Collection collection = await db.Collections
					.Include(c => c.FeedsCollections)
					.FirstOrDefaultAsync(c => c.Id == feedsCollection.CollectionId);
				FeedRSS feed = await db.FeedsRSS.FindAsync(feedsCollection.FeedId);

				if (collection != null && feed != null)
				{
					_logger.LogInformation("Remove feed News: {0} from collection: {1}", feed.Title, collection.Title);
					collection.FeedsCollections.Remove(collection.FeedsCollections.FirstOrDefault(fc => fc.FeedId == feed.Id));
					_logger.LogInformation("Feed News: {0}, was removed from collection: {1}", feed.Title, collection.Title);
				}
				else
				{
					_logger.LogInformation("Collection with title: {0} or feed");
					return NotFound();
				}

				try
				{
					_logger.LogWarning("Try to save changes");
					await db.SaveChangesAsync();
					_logger.LogInformation("Saving changes passed successful.");
					RemoveCollectionRelatedFromCache(collection);
				}
				catch (Exception ex)
				{
					_logger.LogError("Save changes failed with error {0}", ex);
					GetException(ex);
				}
			}
			return Ok(feedsCollection);
		}

		private ArgumentException GetException(Exception ex)
		{
			return new ArgumentException($"Message: {ex.Message}");
		}

		private void RemoveCollectionRelatedFromCache(Collection collection)
		{
			if(collection != null)
			{
				_logger.LogInformation("Clear cache from collections related with the particular user.");
				_memoryCache.Remove(KeysService.KeyCollectionsByOwner(collection.OwnerName));
			}
		}
	}
}