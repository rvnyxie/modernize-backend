using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// Product Group full operations service implementation
    /// </summary>
    public class ProductGroupService : BaseService<ProductGroup, ProductGroupDto, ProductGroupCreationDto, ProductGroupUpdateDto, int>, IProductGroupService
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductGroupService(IProductGroupRepository productGroupRepository, IUnitOfWork unitOfWork) : base(productGroupRepository, unitOfWork)
        {
            _productGroupRepository = productGroupRepository;
            _unitOfWork = unitOfWork;
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
