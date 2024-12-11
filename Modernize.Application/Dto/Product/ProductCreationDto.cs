namespace Modernize.Application
{
    /// <summary>
    /// Product Creation DTO
    /// </summary>
    public class ProductCreationDto : BaseDtoEntity
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
