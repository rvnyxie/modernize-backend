using Modernize.Domain;

namespace Modernize.Application
{
    public class CreateProductGroupCommandHandler : ICommandHandler<CreateProductGroupCommand, ProductGroup>
    {

        public async Task<ProductGroup> HandleAsync(CreateProductGroupCommand command)
        {
            var productGroup = new ProductGroup
            {
                Name = command.Name,
                Description = command.Description
            };

            return productGroup;
        }
    }
}
