namespace Modernize.Application
{
    /// <summary>
    /// Product Group deletion command handler
    /// </summary>
    public class DeleteProductGroupCommandHandler : ICommandHandler<DeleteProductGroupCommand, int>
    {
        private readonly IProductGroupService _productGroupService;

        public DeleteProductGroupCommandHandler(IProductGroupService productGroupService)
        {
            _productGroupService = productGroupService;
        }

        public async Task<int> HandleAsync(DeleteProductGroupCommand command)
        {
            var rowsDeleted = await _productGroupService.DeleteByIdAsync(command.Id);

            return rowsDeleted;
        }
    }
}
