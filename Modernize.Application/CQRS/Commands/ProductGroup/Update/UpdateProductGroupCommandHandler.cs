using AutoMapper;

namespace Modernize.Application
{
    /// <summary>
    /// Product Group update command handler
    /// </summary>
    public class UpdateProductGroupCommandHandler : ICommandHandler<UpdateProductGroupCommand, ProductGroupDto>
    {
        private readonly IProductGroupService _productGroupService;
        private readonly IMapper _mapper;

        public UpdateProductGroupCommandHandler(IProductGroupService productGroupService, IMapper mapper)
        {
            _productGroupService = productGroupService;
            _mapper = mapper;
        }

        public async Task<ProductGroupDto> HandleAsync(UpdateProductGroupCommand command)
        {
            var productGroupUpdateDto = _mapper.Map<ProductGroupUpdateDto>(command);

            var updatedProductGroupDto = await _productGroupService.UpdateAsync(productGroupUpdateDto);

            return updatedProductGroupDto;
        }
    }
}
