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

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var createdEntity = await _context.Set<TEntity>().AddAsync(entity);

            return createdEntity.Entity;
        }

        public async Task<IEnumerable<TEntity>> InsertManyAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);

            return entities;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = _context.Set<TEntity>().Update(entity);

            return Task.FromResult(updatedEntity.Entity);
        }

        public Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);

            return Task.FromResult(entities);
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return Task.FromResult(1);
        }

        public Task<int> DeleteManyAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return Task.FromResult(entities.Count());
        }
    }
}
