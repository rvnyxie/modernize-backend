using Modernize.Domain;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Product readonly repository implementation using Dapper
    /// </summary>
    public class ProductReadonlyRepositoryDapper : BaseReadonlyRepositoryDapper<Product, int>, IProductReadonlyRepository
    {
    }
}
