namespace Modernize.Domain
{
    /// <summary>
    /// Base interface for full operations repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TId">Entity ID type</typeparam>
    public interface IBaseRepository<TEntity, TId> : IBaseReadonlyRepository<TEntity, TId>
    {
        #region CUD

        /// <summary>
        /// Add entity asynchronously
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Add many entities asynchronously
        /// </summary>
        /// <param name="entities">Entities to insert</param>
        /// <returns></returns>
        Task InsertManyAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update entity asynchronously
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Update many entities asynchronously
        /// </summary>
        /// <param name="entities">Entities to update</param>
        /// <returns></returns>
        Task UpdateManyAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Delete entity asynchronously
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Delete many entites asynchronously
        /// </summary>
        /// <param name="entities">Entities to delete</param>
        /// <returns></returns>
        Task DeleteManyAsync(IEnumerable<TEntity> entities);

        #endregion
    }
}
