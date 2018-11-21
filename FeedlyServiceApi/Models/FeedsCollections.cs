using FeedlyServiceApi.Models.RSS;

namespace FeedlyServiceApi.Models
{
	public class FeedsCollections
	{
		public int FeedId { get; set; }
		public Feed Feed { get; set; }

		public int CollectionId { get; set; }
		public Collection Collection { get; set; }
	}
}
