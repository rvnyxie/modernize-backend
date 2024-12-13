using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modernize.Application;

namespace Modernize.API
{
    /// <summary>
    /// Product controller
    /// </summary>
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {

        #region Declaration

        private readonly IQueryHandler<GetAllProductQuery, IEnumerable<ProductDto>> _getAllProductsHandler;

        private readonly ICommandHandler<CreateProductCommand, ProductDto> _createProductHandler;
        private readonly ICommandHandler<UpdateProductCommand, ProductDto> _updateProductHandler;
        private readonly ICommandHandler<DeleteProductCommand, int> _deleteProductHandler;

        #endregion

        #region Constructor

        public ProductsController(
            IQueryHandler<GetAllProductQuery, IEnumerable<ProductDto>> getAllProductsHandler,
            ICommandHandler<CreateProductCommand, ProductDto> createProductHandler,
            ICommandHandler<UpdateProductCommand, ProductDto> updateProductHandler,
            ICommandHandler<DeleteProductCommand, int> deleteProductHandler)
        {
            _getAllProductsHandler = getAllProductsHandler;
            _createProductHandler = createProductHandler;
            _updateProductHandler = updateProductHandler;
            _deleteProductHandler = deleteProductHandler;
        }

        #endregion

        #region GET

        [HttpGet]
        [Authorize(Roles = "Admin, Customer")]
        public async Task<IActionResult> GettAllProducts()
        {
            var products = await _getAllProductsHandler.HandleAsync(new GetAllProductQuery());
            return Ok(products);
        }

        #endregion

        #region POST

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var createdProduct = await _createProductHandler.HandleAsync(command);
            return Ok(createdProduct);
        }

        #endregion

        #region PUT

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            var updatedProduct = await _updateProductHandler.HandleAsync(command);
            return Ok(updatedProduct);
        }

        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var deletedProductId = await _deleteProductHandler.HandleAsync(new DeleteProductCommand { Id = id });
            return Ok(deletedProductId);
        }

        #endregion
    }
}
