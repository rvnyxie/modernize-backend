﻿using Microsoft.EntityFrameworkCore;
using Modernize.Domain;
using Modernize.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernize.Application
{
    public class GetAllProductGroupsQueryHandler : IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroup>>
    {
        private readonly AppDbContext _dbContext;

        public GetAllProductGroupsQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductGroup>> HandleAsync(GetAllProductGroupsQuery query)
        {
            return await _dbContext.ProductGroups.ToListAsync();
        }
    }
}
