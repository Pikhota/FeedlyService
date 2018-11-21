using FeedlyServiceApi.DatabaseContext;
using FeedlyServiceApi.Models.RSS;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace FeedlyServiceApi.Services
{
	public static class DataService
	{
		private static Dictionary<string, ContentName> _nameDictionary = new Dictionary<string, ContentName>()
		{
				{ "title", ContentName.Title },
				{ "description", ContentName.Description }
		};
		private static string[] _sources = 
			{ "https://abcnews.go.com/abcnews/topstories",
				"https://techcrunch.com/feed/",
				"https://habr.com/rss/interesting/",
				"https://censor.net.ua/includes/news_ru.xml" };
		private static List<string> _data = new List<string>();

		public static async Task InitializeData(FeedDbContext context)
		{
			using (WebClient web = new WebClient())
			{
				foreach (var source in _sources)
				{
					string tempData = web.DownloadString(source);
					_data.Add(tempData);
				}

				foreach (var feedsData in _data)
				{
					using (XmlReader xmlReader = XmlReader.Create(new StringReader(feedsData), new XmlReaderSettings() { Async = true }))
					{
						RssFeedReader feedReader = new RssFeedReader(xmlReader);
						FeedRSS feedRSS = new FeedRSS();
						List<ItemRSS> items = new List<ItemRSS>();

						while (await feedReader.Read())
						{
							switch (feedReader.ElementType)
							{
								case SyndicationElementType.Item:
									{
										ISyndicationItem item = await feedReader.ReadItem();

										items.Add(
										 new ItemRSS
										 {
											 Link = item.Links.Where(link =>
											 link.RelationshipType == "alternate").Select(path=>path.Uri.AbsoluteUri).FirstOrDefault(),
											 ImageLink = item.Links
											 .Where(link =>
											 link.MediaType == "image/jpeg" ||
											 link.MediaType == "image/jpg" ||
											 link.MediaType == "image/bmp" ||
											 link.MediaType == "image/png")
											 .Select(path => path.Uri.AbsoluteUri).FirstOrDefault(),

											 Title = item.Title,
											 Description = item.Description,
											 Published = item.Published
										 });
									}
									break;
								case SyndicationElementType.Link:
									{
										ISyndicationLink link = await feedReader.ReadLink();
										feedRSS.Link = link.Uri.AbsoluteUri;
									}
									break;
								case SyndicationElementType.Content:
									{
										ISyndicationContent content = await feedReader.ReadContent();
										switch (_nameDictionary.GetValueOrDefault(content.Name))
										{
											case ContentName.Title:
												feedRSS.Title = content.Value;
												break;
											case ContentName.Description:
												feedRSS.Description = content.Value;
												break;
										}
									}
									break;
							}
						}
						feedRSS.Items = items;
						context.FeedsRSS.Add(feedRSS);
						context.ItemsRSS.AddRange(feedRSS.Items);
						await context.SaveChangesAsync();
					}
				}
			}
		}
	}
}
