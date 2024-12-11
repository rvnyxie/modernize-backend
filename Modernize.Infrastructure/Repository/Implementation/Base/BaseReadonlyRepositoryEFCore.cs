using Microsoft.EntityFrameworkCore;
using Modernize.Domain;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Base readonly repository implementation for EF Core
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TId">Entity ID type</typeparam>
    public class BaseReadonlyRepositoryEFCore<TEntity, TId> : IBaseReadonlyRepository<TEntity, TId>
        where TEntity : class
    {
        private readonly AppDbContext _context;

        public BaseReadonlyRepositoryEFCore(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
