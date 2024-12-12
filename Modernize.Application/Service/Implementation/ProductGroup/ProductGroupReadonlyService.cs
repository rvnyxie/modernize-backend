using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// Product Group readonly service implementation
    /// </summary>
    public class ProductGroupReadonlyService : BaseReadonlyService<ProductGroup, ProductGroupDto, int>, IProductGroupReadonlyService
    {
        private readonly IProductGroupReadonlyRepository _productGroupReadonlyRepository;

        public ProductGroupReadonlyService(IProductGroupReadonlyRepository productGroupReadonlyRepository) : base(productGroupReadonlyRepository)
        {
            _productGroupReadonlyRepository = productGroupReadonlyRepository;
        }

        public override ProductGroupDto MapEntityToDto(ProductGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}
