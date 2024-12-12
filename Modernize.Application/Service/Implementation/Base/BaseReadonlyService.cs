using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// Base readonly service implementation
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TDtoEntity">DTO Entity type</typeparam>
    /// <typeparam name="TId">Entity ID type</typeparam>
    public abstract class BaseReadonlyService<TEntity, TDtoEntity, TId> : IBaseReadonlyService<TDtoEntity, TId>
    {
        protected readonly IBaseReadonlyRepository<TEntity, TId> BaseReadonlyRepository;

        public BaseReadonlyService(IBaseReadonlyRepository<TEntity, TId> baseReadonlyRepository)
        {
            BaseReadonlyRepository = baseReadonlyRepository;
        }

        public async Task<IEnumerable<TDtoEntity>> GetAllAsync()
        {
            var entities = await BaseReadonlyRepository.GetAllAsync();

            var dtoEntities = entities.Select(entity => MapEntityToDto(entity));

            return dtoEntities;
        }

        public async Task<TDtoEntity> GetByIdAsync(TId id)
        {
            var entity = await BaseReadonlyRepository.GetByIdAsync(id);

            var dtoEntity = MapEntityToDto(entity);

            return dtoEntity;
        }

        /// <summary>
        /// Map from entity to DTO entity
        /// </summary>
        /// <param name="entity">Entity need to be mapped</param>
        /// <returns>Corresponding DTO Entity</returns>
        public abstract TDtoEntity MapEntityToDto(TEntity entity);
    }
}
