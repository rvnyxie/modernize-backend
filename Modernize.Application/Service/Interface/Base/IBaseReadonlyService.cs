namespace Modernize.Application
{
    /// <summary>
    /// Base readonly interface service
    /// </summary>
    /// <typeparam name="TDtoEntity">DTO Entity type for returning to client</typeparam>
    /// <typeparam name="TId">DTO entity type</typeparam>
    public interface IBaseReadonlyService<TDtoEntity, TId>
    {
        /// <summary>
        /// Get all DTO entities
        /// </summary>
        /// <returns>All DTO entites</returns>
        Task<IEnumerable<TDtoEntity>> GetAllAsync();

        /// <summary>
        /// Get DTO entity by ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>DTO entity</returns>
        Task<TDtoEntity> GetByIdAsync(TId id);
    }
}
