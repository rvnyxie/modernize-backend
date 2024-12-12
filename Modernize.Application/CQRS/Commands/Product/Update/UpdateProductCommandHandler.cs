using AutoMapper;

namespace Modernize.Application
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ProductDto> HandleAsync(UpdateProductCommand command)
        {
            var productUpdateDto = _mapper.Map<ProductUpdateDto>(command);

            await _productService.UpdateAsync(productUpdateDto);

            return _mapper.Map<ProductDto>(productUpdateDto);
        }
    }
}
