namespace Modernize.Application
{
    /// <summary>
    /// Product Group get all query handler
    /// </summary>
    public class GetAllProductGroupsQueryHandler : IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroupDto>>
    {
        #region Declaration

        private readonly IProductGroupReadonlyService _productGroupReadonlyService;

        #endregion

        #region Constructor

        public GetAllProductGroupsQueryHandler(IProductGroupReadonlyService productGroupReadonlyService)
        {
            _productGroupReadonlyService = productGroupReadonlyService;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<ProductGroupDto>> HandleAsync(GetAllProductGroupsQuery query)
        {
            var dtoEntities = await _productGroupReadonlyService.GetAllAsync();

            return dtoEntities;
        }

        #endregion
    }
}
