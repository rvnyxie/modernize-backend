namespace Modernize.Application
{
    /// <summary>
    /// Product group DTO entity
    /// </summary>
    public class ProductGroupDto
    {
        /// <summary>
        /// Product group's ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product group's name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Product group's description
        /// </summary>
        public string? Description { get; set; }
    }
}
