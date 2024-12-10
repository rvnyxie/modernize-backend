using Modernize.Domain;
using Modernize.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Application
{
    public class CreateProductGroupCommandHandler : ICommandHandler<CreateProductGroupCommand>
    {
        private readonly AppDbContext _dbContext;

        public CreateProductGroupCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task HandleAsync(CreateProductGroupCommand command)
        {
            var productGroup = new ProductGroup
            {
                Name = command.Name,
                Description = command.Description
            };

            await _dbContext.AddAsync(productGroup);
            await _dbContext.SaveChangesAsync();
        }
    }
}
