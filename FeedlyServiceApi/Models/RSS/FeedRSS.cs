using System.Collections.Generic;

namespace FeedlyServiceApi.Models.RSS
{
	public class FeedRSS : Feed
	{
		public string Description { get; set; }
		public List<ItemRSS> Items { get; set; }

	}
}
