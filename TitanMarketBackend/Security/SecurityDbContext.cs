using Microsoft.EntityFrameworkCore;
using Security.Entities;

namespace Security
{
    public class SecurityDbContext : DbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options) { }
        
        public DbSet<LoginCustomerEntity> LoginCustomers { get; set; }
    }
}