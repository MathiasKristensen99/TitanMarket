using Microsoft.EntityFrameworkCore;
using TitanMarket.DB.Entities;

namespace TitanMarket.DB
{
    public class TitanMarketDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public TitanMarketDbContext(DbContextOptions<TitanMarketDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity
            {
                Id = 1,
                Name = "Julians hår",
                Price = 1000000
            });
        }
    }
}