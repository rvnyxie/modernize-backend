using Microsoft.AspNetCore.Mvc;
using Modernize.Application;
using Modernize.Domain;

namespace Modernize.API
{
    [ApiController]
    [Route("api/product-groups")]
    public class ProductGroupsController : ControllerBase
    {
        private readonly IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroup>> _getAllProductGroupsHandler;

        private readonly ICommandHandler<CreateProductGroupCommand> _createPProductGroupHandler;

        public ProductGroupsController(
            IQueryHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroup>> getAllProductGroupsHandler,
            ICommandHandler<CreateProductGroupCommand> createPProductGroupHandler)
        {
            _getAllProductGroupsHandler = getAllProductGroupsHandler;
            _createPProductGroupHandler = createPProductGroupHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductGroups()
        {
            var products = await _getAllProductGroupsHandler.HandleAsync(new GetAllProductGroupsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductGroup([FromBody] CreateProductGroupCommand command)
        {
            await _createPProductGroupHandler.HandleAsync(command);
            return Ok();
        }
    }
}
