using System.Collections.Generic;

namespace FeedlyServiceApi.Models
{
	public class Collection
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string OwnerName { get; set; }

		public List<FeedsCollections> FeedsCollections { get; set; } 

		public Collection()
		{
			FeedsCollections = new List<FeedsCollections>();
		}
	}
}
