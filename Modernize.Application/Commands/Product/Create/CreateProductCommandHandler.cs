using Modernize.Domain;
using Modernize.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Application
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly AppDbContext _dbContext;

        public CreateProductCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task HandleAsync(CreateProductCommand command)
        {
            var product = new Product
            {
                Name = command.Name,
                Price = command.Price
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
