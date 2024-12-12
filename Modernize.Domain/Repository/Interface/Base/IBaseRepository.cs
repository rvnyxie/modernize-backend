namespace Modernize.Domain
{
    /// <summary>
    /// Base interface for full operations repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TId">Entity ID type</typeparam>
    public interface IBaseRepository<TEntity, TId> : IBaseReadonlyRepository<TEntity, TId>
    {
        #region INSERT

        /// <summary>
        /// Add entity asynchronously
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Add many entities asynchronously
        /// </summary>
        /// <param name="entities">Entities to insert</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> InsertManyAsync(IEnumerable<TEntity> entities);

        #endregion

        #region UPDATE

        /// <summary>
        /// Update entity asynchronously
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Update many entities asynchronously
        /// </summary>
        /// <param name="entities">Entities to update</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities);

        #endregion

        #region DELETE

        /// <summary>
        /// Delete entity asynchronously
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns></returns>
        Task<int> DeleteAsync(TEntity entity);

        /// <summary>
        /// Delete many entites asynchronously
        /// </summary>
        /// <param name="entities">Entities to delete</param>
        /// <returns></returns>
        Task<int> DeleteManyAsync(IEnumerable<TEntity> entities);

        #endregion
    }
}
