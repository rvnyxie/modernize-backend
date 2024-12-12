using Microsoft.AspNetCore.Mvc;
using Modernize.Application;

namespace Modernize.API
{
    [ApiController]
    [Route("api/product-groups")]
    public class ProductGroupsController : ControllerBase
    {
        #region Declaration

        private readonly IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroupDto>> _getAllProductGroupsHandler;

        private readonly ICommandHandler<CreateProductGroupCommand, ProductGroupDto> _createPProductGroupHandler;
        private readonly ICommandHandler<UpdateProductGroupCommand, ProductGroupDto> _updateProductGroupHandler;
        private readonly ICommandHandler<DeleteProductGroupCommand, int> _deleteProductGroupHandler;

        #endregion

        #region Constructor

        public ProductGroupsController(
            IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroupDto>> getAllProductGroupsHandler,
            ICommandHandler<CreateProductGroupCommand, ProductGroupDto> createPProductGroupHandler,
            ICommandHandler<UpdateProductGroupCommand, ProductGroupDto> updateProductGroupHandler,
            ICommandHandler<DeleteProductGroupCommand, int> deleteProductGroupHandler)
        {
            _getAllProductGroupsHandler = getAllProductGroupsHandler;
            _createPProductGroupHandler = createPProductGroupHandler;
            _updateProductGroupHandler = updateProductGroupHandler;
            _deleteProductGroupHandler = deleteProductGroupHandler;
        }

        #endregion

        #region Methods

        #region GET

        [HttpGet]
        public async Task<IActionResult> GetAllProductGroups()
        {
            var productGroups = await _getAllProductGroupsHandler.HandleAsync(new GetAllProductGroupsQuery());
            return Ok(productGroups);
        }

        #endregion

        #region POST

        [HttpPost]
        public async Task<IActionResult> CreateProductGroup([FromBody] CreateProductGroupCommand command)
        {
            var createdProductGroup = await _createPProductGroupHandler.HandleAsync(command);
            return Ok(createdProductGroup);
        }

        #endregion

        #region PUT

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductGroup(int id, [FromBody] UpdateProductGroupCommand command)
        {
            var updatedProductGroup = await _updateProductGroupHandler.HandleAsync(command);

            return Ok(updatedProductGroup);
        }

        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductGroup(int id, [FromBody] DeleteProductGroupCommand command)
        {
            var rowsDeleted = await _deleteProductGroupHandler.HandleAsync(command);

            return Ok(rowsDeleted);
        }

        #endregion

        #endregion
    }
}
