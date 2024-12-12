using Modernize.Domain;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Base repository implementation for EF Core
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TId">Entity ID type</typeparam>
    public class BaseRepositoryEFCore<TEntity, TId> : BaseReadonlyRepositoryEFCore<TEntity, TId>, IBaseRepository<TEntity, TId>
        where TEntity : class
    {
        private readonly AppDbContext _context;

        public BaseRepositoryEFCore(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task InsertManyAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public Task DeleteManyAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return Task.CompletedTask;
        }
    }
}
