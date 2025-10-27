using Microsoft.EntityFrameworkCore;

namespace Shopify.Models
{
    public class ShopifyContext : DbContext
    {
        public ShopifyContext(DbContextOptions<ShopifyContext> options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ImageModel> ProductImages { get; set; }

    }
}
