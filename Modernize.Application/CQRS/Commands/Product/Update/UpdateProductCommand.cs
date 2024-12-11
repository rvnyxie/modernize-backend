using Modernize.Domain;

namespace Modernize.Application
{
    public class UpdateProductCommand : ICommand<Product>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
