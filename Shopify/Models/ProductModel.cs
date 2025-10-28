namespace Shopify.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public List<ImageModel> Images { get; set; } = new();
    }
}
