using Modernize.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Application.Commands.Product.Delete
{
    internal class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly AppDbContext _dbContext;

        public DeleteProductCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task HandleAsync(DeleteProductCommand command)
        {
            var product = await _dbContext.Products.FindAsync(command.Id);
            
            if (product is null)
            {
                throw new KeyNotFoundException($"Product with ID {command.Id} not found.");
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
