using Modernize.Domain;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Product readonly repository implementation using EF Core
    /// </summary>
    public class ProductReadonlyRepositoryEFCore : BaseReadonlyRepositoryEFCore<Product, int>, IProductReadonlyRepository
    {
        private readonly AppDbContext _context;

        public ProductReadonlyRepositoryEFCore(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
