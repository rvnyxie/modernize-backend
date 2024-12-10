using AutoMapper;
using Modernize.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Application
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task HandleAsync(UpdateProductCommand command)
        {
            var product = await _dbContext.Products.FindAsync(command.Id);

            if (product is null)
            {
                throw new KeyNotFoundException($"Product with ID {command.Id} not found.");
            }

            _mapper.Map(command, product);

            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
