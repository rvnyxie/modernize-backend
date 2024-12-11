using Modernize.Domain;

namespace Modernize.Application
{
    public class CreateProductCommand : ICommand<Product>
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
