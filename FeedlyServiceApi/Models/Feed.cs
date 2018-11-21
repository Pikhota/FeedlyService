using FeedlyServiceApi.Models.RSS;
using System.Collections.Generic;

namespace FeedlyServiceApi.Models
{
	public class Feed
	{
	  public int Id { get; set; }
		public string FeedFormat { get; set; }
		public string Title { get; set; }
		public string Link { get; set; }
		
		public List<FeedsCollections> FeedsCollections { get; set; }

		public Feed()
		{
			FeedsCollections = new List<FeedsCollections>();
		}
	}
}
