namespace Shopify.Models
{
    public class ImageModel
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public int ProductId { get; set; }

        public ProductModel Product { get; set; }
    }
}
