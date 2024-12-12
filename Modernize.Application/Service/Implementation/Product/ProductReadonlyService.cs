using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    public class ProductReadonlyService : BaseReadonlyService<Product, ProductDto, int>, IProductReadonlyService
    {
        private readonly IProductReadonlyRepository _productReadonlyRepository;
        private readonly IMapper _mapper;

        public ProductReadonlyService(IProductReadonlyRepository productReadonlyRepository, IMapper mapper) : base(productReadonlyRepository)
        {
            _productReadonlyRepository = productReadonlyRepository;
            _mapper = mapper;
        }

        public override ProductDto MapEntityToDto(Product product)
        {
            return _mapper.Map<ProductDto>(product);
        }
    }
}
