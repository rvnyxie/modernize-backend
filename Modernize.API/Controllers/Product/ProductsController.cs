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

        private readonly ICommandHandler<CreateProductCommand> _createProductHandler;
        private readonly ICommandHandler<UpdateProductCommand> _updateProductHandler;
        private readonly ICommandHandler<DeleteProductCommand> _deleteProductHandler;

        public ProductsController(
            IQueryHandler<GetAllProductQuery, IEnumerable<Product>> getAllProductsHandler,
            ICommandHandler<CreateProductCommand> createProductHandler,
            ICommandHandler<UpdateProductCommand> updateProductHandler,
            ICommandHandler<DeleteProductCommand> deleteProductHandler)
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
            await _createProductHandler.HandleAsync(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            await _updateProductHandler.HandleAsync(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            await _deleteProductHandler.HandleAsync(new DeleteProductCommand { Id = id });
            return Ok();
        }
    }
}
