using AutoMapper;

namespace Modernize.Application
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ProductDto> HandleAsync(CreateProductCommand command)
        {
            var productCreationDto = _mapper.Map<ProductCreationDto>(command);

            var createdProductDto = await _productService.InsertAsync(productCreationDto);

            return createdProductDto;
        }
    }
}
