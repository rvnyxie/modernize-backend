namespace Modernize.Application
{
    /// <summary>
    /// Base full operations interface service
    /// </summary>
    /// <typeparam name="TCreationDtoEntity">Creation DTO entity type</typeparam>
    /// <typeparam name="TUpdateDtoEntity">Update DTO entity type</typeparam>
    /// <typeparam name="TDtoEntity">DTO entity type</typeparam>
    /// <typeparam name="TId">Entity ID type</typeparam>
    public interface IBaseService<TCreationDtoEntity, TUpdateDtoEntity, TDtoEntity, TId> : IBaseReadonlyService<TDtoEntity, TId>
    {
        /// <summary>
        /// Insert new entity
        /// </summary>
        /// <param name="creationDtoEntity">Creation DTO entity</param>
        /// <returns></returns>
        Task InsertAsync(TCreationDtoEntity creationDtoEntity);

        /// <summary>
        /// Insert many entites
        /// </summary>
        /// <param name="creationDtoEntities">Creation DTO entities</param>
        /// <returns></returns>
        Task InsertManyAsync(IEnumerable<TCreationDtoEntity> creationDtoEntities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="updateDtoEntity">Update DTO entity</param>
        /// <returns></returns>
        Task UpdateAsync(TUpdateDtoEntity updateDtoEntity);

        /// <summary>
        /// Update many entities
        /// </summary>
        /// <param name="updateDtoEntities">Update DTO entities</param>
        /// <returns></returns>
        Task UpdateManyAsync(IEnumerable<TUpdateDtoEntity> updateDtoEntities);

        /// <summary>
        /// Delete entity by ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns></returns>
        Task DeleteByIdAsync(TId id);

        /// <summary>
        /// Delete many entities by IDs
        /// </summary>
        /// <param name="ids">Entity IDs</param>
        /// <returns></returns>
        Task DeleteManyByIdsAsync(IEnumerable<TId> ids);
    }
}
