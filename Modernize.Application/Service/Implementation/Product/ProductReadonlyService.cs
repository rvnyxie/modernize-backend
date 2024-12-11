using Modernize.Domain;

namespace Modernize.Application
{
    public class ProductReadonlyService : BaseReadonlyService<Product, ProductDto, int>, IProductReadonlyService
    {
        private readonly IProductReadonlyRepository _productReadonlyRepository;

        public ProductReadonlyService(IProductReadonlyRepository productReadonlyRepository) : base(productReadonlyRepository)
        {
            _productReadonlyRepository = productReadonlyRepository;
        }

        public override ProductDto MapEntityToDto(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
