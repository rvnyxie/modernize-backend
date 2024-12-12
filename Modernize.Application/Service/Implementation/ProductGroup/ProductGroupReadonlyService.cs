using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// Product Group readonly service implementation
    /// </summary>
    public class ProductGroupReadonlyService : BaseReadonlyService<ProductGroup, ProductGroupDto, int>, IProductGroupReadonlyService
    {
        private readonly IProductGroupReadonlyRepository _productGroupReadonlyRepository;
        private readonly IMapper _mapper;

        public ProductGroupReadonlyService(IProductGroupReadonlyRepository productGroupReadonlyRepository, IMapper mapper) : base(productGroupReadonlyRepository)
        {
            _productGroupReadonlyRepository = productGroupReadonlyRepository;
            _mapper = mapper;
        }

        public override ProductGroupDto MapEntityToDto(ProductGroup entity)
        {
            return _mapper.Map<ProductGroupDto>(entity);
        }
    }
}
