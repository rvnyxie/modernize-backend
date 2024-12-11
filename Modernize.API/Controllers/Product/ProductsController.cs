using Microsoft.AspNetCore.Mvc;
using Modernize.Application;
using Modernize.Domain;

namespace Modernize.API
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IQueryHandler<GetAllProductQuery, IEnumerable<Product>> _getAllProductsHandler;

        private readonly ICommandHandler<CreateProductCommand, Product> _createProductHandler;
        private readonly ICommandHandler<UpdateProductCommand, Product> _updateProductHandler;
        private readonly ICommandHandler<DeleteProductCommand, int> _deleteProductHandler;

        public ProductsController(
            IQueryHandler<GetAllProductQuery, IEnumerable<Product>> getAllProductsHandler,
            ICommandHandler<CreateProductCommand, Product> createProductHandler,
            ICommandHandler<UpdateProductCommand, Product> updateProductHandler,
            ICommandHandler<DeleteProductCommand, int> deleteProductHandler)
        {
            _getAllProductsHandler = getAllProductsHandler;
            _createProductHandler = createProductHandler;
            _updateProductHandler = updateProductHandler;
            _deleteProductHandler = deleteProductHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GettAllProducts()
        {
            var products = await _getAllProductsHandler.HandleAsync(new GetAllProductQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var createdProduct = await _createProductHandler.HandleAsync(command);
            return Ok(createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            var updatedProduct = await _updateProductHandler.HandleAsync(command);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var deletedProductId = await _deleteProductHandler.HandleAsync(new DeleteProductCommand { Id = id });
            return Ok(deletedProductId);
        }
    }
}
