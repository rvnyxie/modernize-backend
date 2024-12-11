using Modernize.Domain;

namespace Modernize.Application
{
    public class CreateProductGroupCommand : ICommand<ProductGroup>
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
