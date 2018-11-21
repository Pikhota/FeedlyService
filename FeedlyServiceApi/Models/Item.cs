using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedlyServiceApi.Models
{
	public abstract class Item
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTimeOffset Published { get; set; }
		public string ImageLink { get; set; }
		public string Link { get; set; }
		public string ItemFormat { get; set; }
	}
}
