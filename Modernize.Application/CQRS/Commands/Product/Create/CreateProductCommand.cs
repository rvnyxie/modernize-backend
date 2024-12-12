namespace Modernize.Application
{
    /// <summary>
    /// Product creation command
    /// </summary>
    public class CreateProductCommand : ICommand<ProductDto>
    {
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
