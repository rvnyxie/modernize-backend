namespace Modernize.Application
{
    /// <summary>
    /// Product Group deletion command
    /// </summary>
    public class DeleteProductGroupCommand : ICommand<int>
    {
        public int Id { get; set; }
    }
}
