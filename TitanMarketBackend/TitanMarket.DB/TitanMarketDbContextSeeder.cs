namespace TitanMarket.DB
{
    public class TitanMarketDbContextSeeder : ITitanMarketDbContextSeeder
    {
        private readonly TitanMarketDbContext _ctx;

        public TitanMarketDbContextSeeder(TitanMarketDbContext context)
        {
            _ctx = context;
        }
        
        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
        }

        public void SeedProduction()
        {
            throw new System.NotImplementedException();
        }
    }
}