using Modernize.Domain;

namespace Modernize.Application
{
    public class ProductService : BaseService<Product, ProductDto, ProductCreationDto, ProductUpdateDto, int>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public override Product MapCreationDtoToEntity(ProductCreationDto? creationDtoEntity)
        {
            throw new NotImplementedException();
        }

        public override ProductDto MapEntityToDto(Product entity)
        {
            throw new NotImplementedException();
        }

        public override Product MapUpdateDtoToEntity(ProductUpdateDto updateDtoEntity)
        {
            throw new NotImplementedException();
        }
    }
}
