namespace Modernize.Domain
{
    /// <summary>
    /// Product entity
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Product's ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product's name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Product's price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product's quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Reference to a product group
        /// </summary>
        public ProductGroup? Group { get; set; }
    }
}
