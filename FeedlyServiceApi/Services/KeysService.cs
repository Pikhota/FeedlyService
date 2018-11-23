using FeedlyServiceApi.Models;

namespace FeedlyServiceApi.Services
{
	public static class KeysService
	{
		private const string PREFIX_COLLECTION = "collection_";
		private const string PREFIX_ITEMS = "items_";
		private const string PREFIX_ALL_FEEDS = "all_feeds";
		private const string PREFIX_OWNER_COLLECTIONS = "owner_collections_";

		public static string KeyCollectionByFeedsCollection(FeedsCollections feedsCollections)
		{
			return feedsCollections != null ? $"{PREFIX_COLLECTION}{feedsCollections.CollectionId}{feedsCollections.FeedId}": string.Empty;
		}

		public static string KeyAllItems()
		{
			return $"{PREFIX_ITEMS}";
		}

		public static string KeyItems(int feedId)
		{
			return feedId > 0 ? $"{PREFIX_ITEMS}{feedId}" : string.Empty;
		}

		public static string KeyCollectionsByOwner(string ownerName)
		{
			return string.IsNullOrEmpty(ownerName) ? string.Empty : $"{PREFIX_OWNER_COLLECTIONS}{ownerName}";
		}
	}
}
