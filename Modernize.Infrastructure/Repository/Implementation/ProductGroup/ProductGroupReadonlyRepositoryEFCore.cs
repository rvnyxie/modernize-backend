using Modernize.Domain;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Product group readonly repository implementation using EF Core
    /// </summary>
    public class ProductGroupReadonlyRepositoryEFCore : BaseReadonlyRepositoryEFCore<ProductGroup, int>, IProductGroupReadonlyRepository
    {
        private readonly AppDbContext _context;

        public ProductGroupReadonlyRepositoryEFCore(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
