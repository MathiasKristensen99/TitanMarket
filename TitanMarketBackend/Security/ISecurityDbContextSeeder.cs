namespace Security
{
    public interface ISecurityDbContextSeeder
    {
        void SeedDevelopment();

        void SeedProduction();
    }
}