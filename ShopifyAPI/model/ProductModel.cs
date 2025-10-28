namespace ShopifyAPI.model
{
    /// <summary>
    /// Represents a product in the Shopify API.
    /// </summary>
    public class ProductModel
    {
        /// <summary>ID of Product/// </summary>
        /// <example>1</example>
        public int Id { get; set; }
        /// <summary>Name of Product/// </summary>
        /// <example>T-Shirts</example>
        public string Title { get; set; }

        /// <summary>Quantity of Product/// </summary>
        /// <example>1</example>
        public int Quantity { get; set; }

        /// <summary>Price of Product/// </summary>
        /// <example>100</example>
        public decimal Price { get; set; }
    }
}

