using Modernize.Domain;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Product group full operations repository implementation using EF Core
    /// </summary>
    public class ProductGroupRepositoryEFCore : BaseRepositoryEFCore<ProductGroup, int>, IProductGroupRepository
    {
        private readonly AppDbContext _context;

        public ProductGroupRepositoryEFCore(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
