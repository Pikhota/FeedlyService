using System;

namespace FeedlyServiceApi.Models.RSS
{
	public class ItemRSS : Item
	{
		public int? FeedId { get; set; }
		public FeedRSS FeedRSS { get; set; }
	}
}