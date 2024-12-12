using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    public class ProductService : BaseService<Product, ProductDto, ProductCreationDto, ProductUpdateDto, int>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(productRepository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override Product MapCreationDtoToEntity(ProductCreationDto? creationDtoProduct)
        {
            return _mapper.Map<Product>(creationDtoProduct);
        }

        public override ProductDto MapEntityToDto(Product product)
        {
            return _mapper.Map<ProductDto>(product);
        }

        public override Product MapUpdateDtoToEntity(ProductUpdateDto updateDtoProduct)
        {
            return _mapper.Map<Product>(updateDtoProduct);
        }
    }
}
