using System.Collections.Generic;
using FeedlyServiceApi.Models;
using FeedlyServiceApi.Models.RSS;

namespace TestWebClient.Models
{
	public class ViewModel 
	{
		public IEnumerable<ItemRSS> Items { get; set; }
		public IEnumerable<FeedRSS> Feeds { get; set; }
		public Collection  Collection { get; set; }
		public PageViewModel PageViewModel { get; set; }
		public ItemRSS Item { get; set; }
	}
}
