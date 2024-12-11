using Modernize.Infrastructure;

namespace Modernize.Application.Commands.Product.Delete
{
    internal class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, int>
    {
        private readonly AppDbContext _dbContext;

        public DeleteProductCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> HandleAsync(DeleteProductCommand command)
        {
            var product = await _dbContext.Products.FindAsync(command.Id);

            if (product is null)
            {
                throw new KeyNotFoundException($"Product with ID {command.Id} not found.");
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return command.Id;
        }
    }
}
