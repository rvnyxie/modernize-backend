namespace Modernize.Application
{
    /// <summary>
    /// Product update command
    /// </summary>
    public class UpdateProductCommand : ICommand<ProductDto>
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
    }
}
