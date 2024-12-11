namespace Modernize.Domain
{
    /// <summary>
    /// Base interface for readonly repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TId">Entity ID type</typeparam>
    public interface IBaseReadonlyRepository<TEntity, TId>
    {
        #region Get many records

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>All entities</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        #endregion

        #region Get single record

        /// <summary>
        /// Get entity by ID
        /// </summary>
        /// <param name="id">ID of entity</param>
        /// <returns>Entity with specified ID</returns>
        Task<TEntity?> GetByIdAsync(TId id);

        #endregion
    }
}
