using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// Base full operations service implementation
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TDtoEntity">DTO entity type</typeparam>
    /// <typeparam name="TCreationDtoEntity">Creation DTO entity type</typeparam>
    /// <typeparam name="TUpdateDtoEntity">Update DTO entity type</typeparam>
    /// <typeparam name="TId">Entity ID type</typeparam>
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

        public async Task<TDtoEntity> InsertAsync(TCreationDtoEntity creationDtoEntity)
        {
            var entity = MapCreationDtoToEntity(creationDtoEntity);

            var createdEntity = await BaseRepository.InsertAsync(entity);

            await UnitOfWork.SaveChangesAsync();

            var createdDtoEntity = MapEntityToDto(createdEntity);

            return createdDtoEntity;
        }

        public async Task<IEnumerable<TDtoEntity>> InsertManyAsync(IEnumerable<TCreationDtoEntity> creationDtoEntities)
        {
            var entities = creationDtoEntities.Select(creationDtoEntity => MapCreationDtoToEntity(creationDtoEntity));

            var createdEntites = await BaseRepository.InsertManyAsync(entities);

            await UnitOfWork.SaveChangesAsync();

            var createdDtoEntities = createdEntites.Select(entity => MapEntityToDto(entity));

            return createdDtoEntities;
        }

        public async Task<TDtoEntity> UpdateAsync(TUpdateDtoEntity updateDtoEntity)
        {
            var entity = MapUpdateDtoToEntity(updateDtoEntity);

            var updatedEntity = await BaseRepository.UpdateAsync(entity);

            await UnitOfWork.SaveChangesAsync();

            var updatedDtoEntity = MapEntityToDto(updatedEntity);

            return updatedDtoEntity;
        }

        public async Task<IEnumerable<TDtoEntity>> UpdateManyAsync(IEnumerable<TUpdateDtoEntity> updateDtoEntities)
        {
            var entities = updateDtoEntities.Select(updateDtoEntity => MapUpdateDtoToEntity(updateDtoEntity));

            var updatedEntities = await BaseRepository.UpdateManyAsync(entities);

            await UnitOfWork.SaveChangesAsync();

            var updatedDtoEntites = Enumerable.Empty<TDtoEntity>();

            if (updatedEntities.Any())
            {
                updatedDtoEntites = updatedEntities.Select(entity => MapEntityToDto(entity));
            }

            return updatedDtoEntites;
        }

        public async Task<int> DeleteByIdAsync(TId id)
        {
            var entity = await BaseRepository.GetByIdAsync(id);

            var recordsDeleted = 0;

            if (entity is not null)
            {
                recordsDeleted = await BaseRepository.DeleteAsync(entity);
                await UnitOfWork.SaveChangesAsync();
            }

            return recordsDeleted;
        }

        public async Task<int> DeleteManyByIdsAsync(IEnumerable<TId> ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Map from creation DTO entity to entity
        /// </summary>
        /// <param name="creationDtoEntity">Creation DTO entity need to be mapped</param>
        /// <returns>Corresponding entity</returns>
        public abstract TEntity MapCreationDtoToEntity(TCreationDtoEntity? creationDtoEntity);

        /// <summary>
        /// Map from update DTO entity to entity
        /// </summary>
        /// <param name="updateDtoEntity">Update DTO entity need to be mapped</param>
        /// <returns>Corresponding entity</returns>
        public abstract TEntity MapUpdateDtoToEntity(TUpdateDtoEntity updateDtoEntity);
    }
}
