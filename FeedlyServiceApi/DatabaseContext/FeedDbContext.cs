using FeedlyServiceApi.Models;
using FeedlyServiceApi.Models.RSS;
using Microsoft.EntityFrameworkCore;
using System;

namespace FeedlyServiceApi.DatabaseContext
{
	public class FeedDbContext : DbContext
	{
		public DbSet<Collection> Collections { get; set; }
		public DbSet<Feed> Feeds { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<FeedRSS> FeedsRSS { get; set; }
		public DbSet<ItemRSS> ItemsRSS { get; set; }

		public FeedDbContext(DbContextOptions<FeedDbContext> options) 
			: base(options)
		{
			Database.AutoTransactionsEnabled = true;
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Feed>(f =>
			{
				f.HasDiscriminator<string>("FeedFormat");
				f.Property(prop => prop.FeedFormat).HasColumnName("Format");
			});

			modelBuilder.Entity<Item>(
				item =>
				{
					item.HasDiscriminator<string>("ItemFormat");
					item.Property(prop => prop.ItemFormat).HasColumnName("Format");
				});

			modelBuilder.Entity<ItemRSS>()
				.HasOne(f => f.FeedRSS)
				.WithMany(i => i.Items).HasForeignKey(key => key.FeedId);

			modelBuilder.Entity<FeedRSS>()
				.HasMany(i=>i.Items).WithOne(f=>f.FeedRSS).HasForeignKey(key=>key.FeedId);

			modelBuilder.Entity<FeedsCollections>()
				.HasKey(key => new { key.CollectionId, key.FeedId });

			modelBuilder.Entity<FeedsCollections>()
				.HasOne(f => f.Feed)
				.WithMany(fc => fc.FeedsCollections)
				.HasForeignKey(key => key.FeedId);

			modelBuilder.Entity<FeedsCollections>()
				.HasOne(c => c.Collection)
				.WithMany(fc => fc.FeedsCollections)
				.HasForeignKey(key => key.CollectionId);
		}
	}
}
