using Modernize.Domain;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Product full operations repository implementation using EF Core
    /// </summary>
    public class ProductRepositoryEFCore : BaseRepositoryEFCore<Product, int>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepositoryEFCore(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
