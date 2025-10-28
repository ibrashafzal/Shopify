using Microsoft.EntityFrameworkCore;
using ShopifyAPI.model;

namespace ShopifyApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
