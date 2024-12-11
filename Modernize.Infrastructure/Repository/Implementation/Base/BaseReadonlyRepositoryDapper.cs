using Modernize.Domain;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Base readonly repository implementation using Dapper
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TId">Entity ID type</typeparam>
    public class BaseReadonlyRepositoryDapper<TEntity, TId> : IBaseReadonlyRepository<TEntity, TId>
    {
        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetByIdAsync(TId id)
        {
            throw new NotImplementedException();
        }
    }
}
