using EasyCargo.Api.Domains;
using Microsoft.EntityFrameworkCore;

namespace EasyCargo.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}