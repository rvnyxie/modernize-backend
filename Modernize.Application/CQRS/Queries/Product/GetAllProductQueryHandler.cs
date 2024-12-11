namespace Modernize.Application
{
    public class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductReadonlyService _productReadonlyService;

        public GetAllProductQueryHandler(IProductReadonlyService productReadonlyService)
        {
            _productReadonlyService = productReadonlyService;
        }

        public async Task<IEnumerable<ProductDto>> HandleAsync(GetAllProductQuery command)
        {
            return await _productReadonlyService.GetAllAsync();
        }
    }
}
