using Modernize.Domain;

namespace Modernize.Application
{
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

        public abstract TDtoEntity MapEntityToDto(TEntity entity);
    }
}
