using Microsoft.EntityFrameworkCore;
using Modernize.Domain;
using Modernize.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Application
{
    public class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly AppDbContext _dbContext;

        public GetAllProductQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> HandleAsync(GetAllProductQuery command)
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
