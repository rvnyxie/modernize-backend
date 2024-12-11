using Modernize.Domain;

namespace Modernize.Application
{
    public class ProductGroupService : BaseService<ProductGroup, ProductGroupDto, ProductGroupCreationDto, ProductGroupUpdateDto, int>, IProductGroupService
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupService(IProductGroupRepository productGroupRepository) : base(productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }

        public override ProductGroup MapCreationDtoToEntity(ProductGroupCreationDto? creationDtoEntity)
        {
            throw new NotImplementedException();
        }

        public override ProductGroupDto MapEntityToDto(ProductGroup entity)
        {
            throw new NotImplementedException();
        }

        public override ProductGroup MapUpdateDtoToEntity(ProductGroupUpdateDto updateDtoEntity)
        {
            throw new NotImplementedException();
        }
    }
}
