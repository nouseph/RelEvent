using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogEventContext : DbContext
    {
        //Constructor
        public CatalogEventContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CatalogEventCategory> CatalogEventCategories { get; set; }
        public DbSet<CatalogEventItem> CatalogEventItems { get; set; }
        public DbSet<CatalogEventType> CatalogEventTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogEventCategory>(e =>
            {
                e.ToTable("CatalogEventCategories");

                e.Property(c => c.Id)
                .IsRequired()
                .UseHiLo("catalog_event_category_hilo");

                e.Property(c => c.Category)
                .IsRequired()
                .HasMaxLength(100);

            });

            modelBuilder.Entity<CatalogEventType>(e =>
            {
                e.ToTable("CatalogEventTypes");

                e.Property(t => t.Id)
                .IsRequired()
                .UseHiLo("catalog_event_type_hilo");

                e.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(100);

            });

            modelBuilder.Entity<CatalogEventItem>(e =>
            {
                e.ToTable("CatalogEventItems");

                e.Property(i => i.Id)
                .IsRequired()
                .UseHiLo("catalog_event_item_hilo");

                e.Property(i => i.Name)
               .IsRequired()
               .HasMaxLength(100);

                e.Property(i => i.Description)
                //.IsRequired()
                .HasMaxLength(500);

                e.Property(i => i.Date)
                .IsRequired();

                e.Property(i => i.Location)
                .IsRequired();

                e.Property(i => i.PictureUrl)
                /*.IsRequired()*/;

                e.Property(i => i.Price)
                .IsRequired();

                e.Property(i => i.EventHost)
                .IsRequired();

                e.HasOne(i => i.CatalogEventCategory)
                .WithMany()
                .HasForeignKey(i => i.CatalogEventCategoryId);

                e.HasOne(i => i.CatalogEventType)
                .WithMany()
                .HasForeignKey(i => i.CatalogEventTypeId);
            });
        }
    }
}
