namespace TitanMarket.DB
{
    public interface ITitanMarketDbContextSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}