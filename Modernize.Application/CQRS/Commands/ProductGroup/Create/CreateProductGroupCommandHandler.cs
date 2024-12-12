using AutoMapper;

namespace Modernize.Application
{
    /// <summary>
    /// Product Group creation command handler
    /// </summary>
    public class CreateProductGroupCommandHandler : ICommandHandler<CreateProductGroupCommand, ProductGroupDto>
    {
        private readonly IProductGroupService _productGroupService;
        private readonly IMapper _mapper;

        public CreateProductGroupCommandHandler(IProductGroupService productGroupService, IMapper mapper)
        {
            _productGroupService = productGroupService;
            _mapper = mapper;
        }

        public async Task<ProductGroupDto> HandleAsync(CreateProductGroupCommand command)
        {
            var creationDtoEntity = _mapper.Map<ProductGroupCreationDto>(command);

            var createdDtoEntity = await _productGroupService.InsertAsync(creationDtoEntity);

            return createdDtoEntity;
        }
    }
}
