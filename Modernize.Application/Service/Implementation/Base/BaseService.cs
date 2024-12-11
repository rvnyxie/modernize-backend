using Modernize.Domain;

namespace Modernize.Application
{
    public abstract class BaseService<TEntity, TDtoEntity, TCreationDtoEntity, TUpdateDtoEntity, TId>
        : BaseReadonlyService<TEntity, TDtoEntity, TId>, IBaseService<TCreationDtoEntity, TUpdateDtoEntity, TDtoEntity, TId>
    {
        protected readonly IBaseRepository<TEntity, TId> BaseRepository;

        public BaseService(IBaseRepository<TEntity, TId> baseRepository) : base(baseRepository)
        {
            BaseRepository = baseRepository;
        }

        public async Task InsertAsync(TCreationDtoEntity creationDtoEntity)
        {
            var entity = MapCreationDtoToEntity(creationDtoEntity);

            await BaseRepository.InsertAsync(entity);
        }

        public async Task InsertManyAsync(IEnumerable<TCreationDtoEntity> creationDtoEntities)
        {
            var entities = creationDtoEntities.Select(creationDtoEntity => MapCreationDtoToEntity(creationDtoEntity));

            await BaseRepository.InsertManyAsync(entities);
        }

        public async Task UpdateAsync(TUpdateDtoEntity updateDtoEntity)
        {
            var entity = MapUpdateDtoToEntity(updateDtoEntity);

            await BaseRepository.UpdateAsync(entity);
        }

        public async Task UpdateManyAsync(IEnumerable<TUpdateDtoEntity> updateDtoEntities)
        {
            var entities = updateDtoEntities.Select(updateDtoEntity => MapUpdateDtoToEntity(updateDtoEntity));

            await BaseRepository.UpdateManyAsync(entities);
        }

        public async Task DeleteByIdAsync(TId id)
        {
            var entity = await BaseRepository.GetByIdAsync(id);

            if (entity is not null)
            {
                await BaseRepository.DeleteAsync(entity);
            }
        }

        public async Task DeleteManyByIdsAsync(IEnumerable<TId> ids)
        {
            throw new NotImplementedException();
        }

        public abstract TEntity MapCreationDtoToEntity(TCreationDtoEntity? creationDtoEntity);

        public abstract TEntity MapUpdateDtoToEntity(TUpdateDtoEntity updateDtoEntity);
    }
}
