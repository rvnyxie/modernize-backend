using Modernize.Domain;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Product group readonly repository implementation using Dapper
    /// </summary>
    public class ProductGroupReadonlyRepositoryDapper : BaseReadonlyRepositoryDapper<ProductGroup, int>, IProductGroupReadonlyRepository
    {
    }
}
