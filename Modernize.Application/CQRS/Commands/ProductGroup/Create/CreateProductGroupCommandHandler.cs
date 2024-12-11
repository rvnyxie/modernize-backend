using Modernize.Domain;
using Modernize.Infrastructure;

namespace Modernize.Application
{
    public class CreateProductGroupCommandHandler : ICommandHandler<CreateProductGroupCommand, ProductGroup>
    {
        private readonly AppDbContext _dbContext;

        public CreateProductGroupCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductGroup> HandleAsync(CreateProductGroupCommand command)
        {
            var productGroup = new ProductGroup
            {
                Name = command.Name,
                Description = command.Description
            };

            await _dbContext.AddAsync(productGroup);
            await _dbContext.SaveChangesAsync();

            return productGroup;
        }
    }
}
