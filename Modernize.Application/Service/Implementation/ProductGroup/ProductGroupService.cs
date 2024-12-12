using AutoMapper;
using Modernize.Domain;

namespace Modernize.Application
{
    /// <summary>
    /// Product Group full operations service implementation
    /// </summary>
    public class ProductGroupService : BaseService<ProductGroup, ProductGroupDto, ProductGroupCreationDto, ProductGroupUpdateDto, int>, IProductGroupService
    {
        #region Declaration

        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ProductGroupService(IProductGroupRepository productGroupRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(productGroupRepository, unitOfWork)
        {
            _productGroupRepository = productGroupRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public override ProductGroup MapCreationDtoToEntity(ProductGroupCreationDto? creationDtoEntity)
        {
            return _mapper.Map<ProductGroup>(creationDtoEntity);
        }

        public override ProductGroupDto MapEntityToDto(ProductGroup entity)
        {
            return _mapper.Map<ProductGroupDto>(entity);
        }

        public override ProductGroup MapUpdateDtoToEntity(ProductGroupUpdateDto updateDtoEntity)
        {
            return _mapper.Map<ProductGroup>(updateDtoEntity);
        }

        #endregion
    }
}
