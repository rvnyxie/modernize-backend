using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    public class BaseReadonlyService<TEntity, TDtoEntity, TId> : IBaseReadonlyService<TDtoEntity, TId>
    {
        protected readonly IBaseReadonlyRepository<TEntity, TId> BaseReadonlyRepository;
        protected readonly IMapper Mapper;

        public BaseReadonlyService(IBaseReadonlyRepository<TEntity, TId> baseReadonlyRepository, IMapper mapper)
        {
            BaseReadonlyRepository = baseReadonlyRepository;
            Mapper = mapper;
        }

        public async Task<IEnumerable<TDtoEntity>> GetAllAsync()
        {
            var entities = await BaseReadonlyRepository.GetAllAsync();

            var dtoEntities = entities.Select(entity => Mapper.Map(TEntity, TDtoEntiy)).ToList();

            return dtoEntities;
        }

        public Task<TDtoEntity> GetByIdAsync(TId id)
        {
            throw new NotImplementedException();
        }
    }
}
