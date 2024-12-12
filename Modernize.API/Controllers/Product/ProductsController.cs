﻿using Microsoft.AspNetCore.Mvc;
using Modernize.Application;

namespace Modernize.API
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        #region Query

        private readonly IQueryHandler<GetAllProductQuery, IEnumerable<ProductDto>> _getAllProductsHandler;

        #endregion

        #region Command

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
        public async Task<IActionResult> GettAllProducts()
        {
            var products = await _getAllProductsHandler.HandleAsync(new GetAllProductQuery());
            return Ok(products);
        }

        #region

        #region POST

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var createdProduct = await _createProductHandler.HandleAsync(command);
            return Ok(createdProduct);
        }

        #endregion

        #region PUT

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            var updatedProduct = await _updateProductHandler.HandleAsync(command);
            return Ok(updatedProduct);
        }

        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var deletedProductId = await _deleteProductHandler.HandleAsync(new DeleteProductCommand { Id = id });
            return Ok(deletedProductId);
        }

        #endregion
    }
}
