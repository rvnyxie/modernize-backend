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
        /// <returns>Created DTO entity</returns>
        Task<TDtoEntity> InsertAsync(TCreationDtoEntity creationDtoEntity);

        /// <summary>
        /// Insert many entites
        /// </summary>
        /// <param name="creationDtoEntities">Creation DTO entities</param>
        /// <returns>Many created DTO entities</returns>
        Task<IEnumerable<TDtoEntity>> InsertManyAsync(IEnumerable<TCreationDtoEntity> creationDtoEntities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="updateDtoEntity">Update DTO entity</param>
        /// <returns>Updated DTO entities</returns>
        Task<TDtoEntity> UpdateAsync(TUpdateDtoEntity updateDtoEntity);

        /// <summary>
        /// Update many entities
        /// </summary>
        /// <param name="updateDtoEntities">Update DTO entities</param>
        /// <returns>Many updated DTO entities</returns>
        Task<IEnumerable<TDtoEntity>> UpdateManyAsync(IEnumerable<TUpdateDtoEntity> updateDtoEntities);

        /// <summary>
        /// Delete entity by ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Number of records deleted</returns>
        Task<int> DeleteByIdAsync(TId id);

        /// <summary>
        /// Delete many entities by IDs
        /// </summary>
        /// <param name="ids">Entity IDs</param>
        /// <returns>Number of records deleted</returns>
        Task<int> DeleteManyByIdsAsync(IEnumerable<TId> ids);
    }
}
