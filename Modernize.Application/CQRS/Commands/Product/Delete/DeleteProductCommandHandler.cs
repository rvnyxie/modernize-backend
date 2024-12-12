namespace Modernize.Application.Commands.Product.Delete
{
    internal class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, int>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<int> HandleAsync(DeleteProductCommand command)
        {
            var rowsDeleted = await _productService.DeleteByIdAsync(command.Id);
            return rowsDeleted;
        }
    }
}
