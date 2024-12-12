namespace Modernize.Application
{
    /// <summary>
    /// Product Group get all query handler
    /// </summary>
    public class GetAllProductGroupsQueryHandler : IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroupDto>>
    {
        private readonly IProductGroupReadonlyService _productGroupReadonlyService;

        public GetAllProductGroupsQueryHandler(IProductGroupReadonlyService productGroupReadonlyService)
        {
            _productGroupReadonlyService = productGroupReadonlyService;
        }

        public async Task<IEnumerable<ProductGroupDto>> HandleAsync(GetAllProductGroupsQuery query)
        {
            var dtoEntities = await _productGroupReadonlyService.GetAllAsync();

            return dtoEntities;
        }
    }
}
