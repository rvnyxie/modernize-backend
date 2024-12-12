using Modernize.Domain;

namespace Modernize.Application
{
    public abstract class BaseService<TEntity, TDtoEntity, TCreationDtoEntity, TUpdateDtoEntity, TId>
        : BaseReadonlyService<TEntity, TDtoEntity, TId>, IBaseService<TCreationDtoEntity, TUpdateDtoEntity, TDtoEntity, TId>
    {
        protected readonly IBaseRepository<TEntity, TId> BaseRepository;
        protected readonly IUnitOfWork UnitOfWork;

        public BaseService(IBaseRepository<TEntity, TId> baseRepository, IUnitOfWork unitOfWork) : base(baseRepository)
        {
            BaseRepository = baseRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task InsertAsync(TCreationDtoEntity creationDtoEntity)
        {
            var entity = MapCreationDtoToEntity(creationDtoEntity);

            await BaseRepository.InsertAsync(entity);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task InsertManyAsync(IEnumerable<TCreationDtoEntity> creationDtoEntities)
        {
            var entities = creationDtoEntities.Select(creationDtoEntity => MapCreationDtoToEntity(creationDtoEntity));

            await BaseRepository.InsertManyAsync(entities);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(TUpdateDtoEntity updateDtoEntity)
        {
            var entity = MapUpdateDtoToEntity(updateDtoEntity);

            await BaseRepository.UpdateAsync(entity);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateManyAsync(IEnumerable<TUpdateDtoEntity> updateDtoEntities)
        {
            var entities = updateDtoEntities.Select(updateDtoEntity => MapUpdateDtoToEntity(updateDtoEntity));

            await BaseRepository.UpdateManyAsync(entities);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(TId id)
        {
            var entity = await BaseRepository.GetByIdAsync(id);

            if (entity is not null)
            {
                await BaseRepository.DeleteAsync(entity);
                await UnitOfWork.SaveChangesAsync();
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
