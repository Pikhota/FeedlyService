using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestWebClient.Api;
using TestWebClient.Filters;
using FeedlyServiceApi.Models.RSS;
using FeedlyServiceApi.Models;
using TestWebClient.Models;

namespace TestWebClient.Controllers
{
	[AppExceptionFilter]
	public class HomeController : Controller
	{
		private FeedsApi _api;

		public HomeController()
		{
			_api = new FeedsApi();
		}

		public IActionResult Index()
		{
			ViewBag.Content = ContentState.Default;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> InitializeDataOnServer()
		{
			using (HttpClient client = _api.Initial())
			{
				using (HttpResponseMessage response = await client.PostAsync("api/FeedsNews/LoadData", null))
				{
					response.EnsureSuccessStatusCode();
				}
			} 
			return NoContent();
		}

		[HttpGet]
		public IActionResult GetNewsInfo(string title, string description, string image, string link)
		{
			ViewModel viewModel = new ViewModel();
			ViewBag.Content = ContentState.GetNewsInfo;
			viewModel.Item = new ItemRSS { Title = DecodeContent(title), Description = DecodeContent(description), ImageLink = image, Link = link };
			return View("Index", viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllNews(int page = 1)
		{
			using (HttpClient client = _api.Initial())
			{
				using (HttpResponseMessage response = await client.GetAsync($"api/FeedsNews/GetAllNews"))
				{
					response.EnsureSuccessStatusCode();
					var resultResponse = await response.Content.ReadAsStringAsync();
					List<ItemRSS> items = JsonConvert.DeserializeObject<List<ItemRSS>>(resultResponse);

					ViewBag.Content = ContentState.GetAllNews;

					return View("Index", GetViewModel(items, page, 0));
				}
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateCollection(string userName, Collection collection)
		{
			using (HttpClient client = _api.Initial())
			{
				collection.OwnerName = userName;
				using (HttpResponseMessage response = await client.PostAsJsonAsync("api/FeedsNews/create", collection))
				{
					response.EnsureSuccessStatusCode();
				}
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public async Task<ActionResult> DeleteCollection([FromForm]int id)
		{
			using (HttpClient client = _api.Initial())
			{
				using (HttpResponseMessage response = await client.DeleteAsync($"api/FeedsNews/DeleteCollection/{id}"))
				{
					response.EnsureSuccessStatusCode();
				}
				return RedirectToAction("Index");
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetContent(int contentId, int page = 1)
		{
			using (HttpClient client = _api.Initial())
			{
				using (HttpResponseMessage responseContent = await client.GetAsync($"api/FeedsNews/GetFeedContent/{contentId}"))
				{
					responseContent.EnsureSuccessStatusCode();
					var resultContent = await responseContent.Content.ReadAsStringAsync();
					List<ItemRSS> items = JsonConvert.DeserializeObject<List<ItemRSS>>(resultContent);
					ViewBag.Content = ContentState.GetFeedItems;
					return View("Index", GetViewModel(items, page, contentId));
				}
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetFeedsFromCollection(int contentId, int page = 1)
		{
			using (HttpClient client = _api.Initial())
			{
				using (HttpResponseMessage responseFeeds = await client.GetAsync($"api/FeedsNews/GetFeedsFromCollection/{contentId}"))
				{
					responseFeeds.EnsureSuccessStatusCode();
					var resultResponseFeeds = await responseFeeds.Content.ReadAsStringAsync();
					List<FeedRSS> feedsRss = JsonConvert.DeserializeObject<List<FeedRSS>>(resultResponseFeeds);
					ViewBag.Content = ContentState.GetFeedsFromCollection;
					ViewBag.CollectionId = contentId;
					return View("Index", GetViewModel(feedsRss, page, contentId));
				}
			}
		}

		[HttpPost]
		public async Task<IActionResult> SelectContent(int collectionId)
		{
			ViewModel viewModel = new ViewModel();
			using (HttpClient client = _api.Initial())
			{
				using (HttpResponseMessage responseFeeds = await client.GetAsync($"api/FeedsNews/GetAllFeeds"))
				{
					responseFeeds.EnsureSuccessStatusCode();
					var result = await responseFeeds.Content.ReadAsStringAsync();
					viewModel.Feeds = JsonConvert.DeserializeObject<List<FeedRSS>>(result);
					viewModel.Collection = await GetCollectionAsync(client, collectionId);
				}
			}
			ViewBag.CollectionId = collectionId;
			ViewBag.Content = ContentState.EditContent;
			return PartialView("_contentList", viewModel);
		}

		public async Task<IActionResult> UpdateContent(int contentId)
		{
			ViewModel viewModel = new ViewModel();
			using (HttpClient client = _api.Initial())
			{
				using (HttpResponseMessage responseFeeds = await client.GetAsync($"api/FeedsNews/GetAllFeeds"))
				{
					responseFeeds.EnsureSuccessStatusCode();
					var result = responseFeeds.Content.ReadAsStringAsync().Result;
					viewModel.Feeds = JsonConvert.DeserializeObject<IEnumerable<FeedRSS>>(result).ToList();
					viewModel.Collection = await GetCollectionAsync(client, contentId);
				}

				ViewBag.CollectionId = contentId;
				ViewBag.Content = ContentState.EditContent;
				return View("Index", viewModel);
			}
		}

		private async Task<Collection> GetCollectionAsync(HttpClient client, int id)
		{
			using (HttpResponseMessage responseCollection = await client.GetAsync($"api/FeedsNews/GetCollection/{id}"))
			{
				responseCollection.EnsureSuccessStatusCode();
				var resultCollection = await responseCollection.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<Collection>(resultCollection);
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddContentToCollection([FromForm]int collectionId, [FromForm]int feedId)
		{
			using (HttpClient client = _api.Initial())
			{

				using (HttpResponseMessage responseAdd = await client.PutAsJsonAsync($"api/FeedsNews/AddContentToCollection", new FeedsCollections { CollectionId = collectionId, FeedId = feedId }))
				{
					responseAdd.EnsureSuccessStatusCode();
				}
			}
			return RedirectToAction("UpdateContent", new { contentId = collectionId });
		}

		[HttpPost]
		public async Task<IActionResult> DeleteContentFromCollection([FromForm]int collectionId, [FromForm]int feedId)
		{
				using (HttpClient client = _api.Initial())
				{

					using (HttpResponseMessage response = await client.PostAsJsonAsync($"api/FeedsNews/DeleteContentFromCollection", new FeedsCollections { CollectionId = collectionId, FeedId = feedId }))
					{
						response.EnsureSuccessStatusCode();
					}
				}
			return RedirectToAction("UpdateContent", new { contentId = collectionId });
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private async Task<IEnumerable<FeedRSS>> UpdateData(HttpClient client, int collectionId)
		{
			ViewBag.CollectionId = collectionId;
			using (HttpResponseMessage responseFeeds = await client.GetAsync($"api/FeedsNews/GetAllFeeds"))
			{
				responseFeeds.EnsureSuccessStatusCode();
				var resultResponseFeeds = await responseFeeds.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<IEnumerable<FeedRSS>>(resultResponseFeeds);
			}
		}

		private ViewModel GetViewModel(IEnumerable<ItemRSS> items, int page, int indexContent)
		{
			int pageSize = 10;
			int count = items.Count();

			PageViewModel pageViewModel = new PageViewModel(count, page, pageSize, indexContent);
			ViewModel viewModel = new ViewModel
			{
				PageViewModel = pageViewModel,
				Items = items.Skip((page - 1) * pageSize).Take(pageSize),
			};

			return viewModel;
		}

		private ViewModel GetViewModel(IEnumerable<FeedRSS> feedsRss, int page, int indexContent)
		{
			int pageSize = 10;
			int count = feedsRss.SelectMany(f => f.Items).Count();
			IEnumerable<ItemRSS> itemsRss = feedsRss.SelectMany(i => i.Items);

			PageViewModel pageViewModel = new PageViewModel(count, page, pageSize, indexContent);
			ViewModel viewModel = new ViewModel
			{
				PageViewModel = pageViewModel,
				Items = itemsRss.Skip((page - 1) * pageSize).Take(pageSize),
				Feeds = feedsRss
			};

			return viewModel;
		}

		private string DecodeContent(string str)
		{
			return HttpUtility.HtmlDecode(str).ToString();
		}
	}
}
