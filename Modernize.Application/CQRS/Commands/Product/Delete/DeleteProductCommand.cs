namespace Modernize.Application
{
    public class DeleteProductCommand : ICommand<int>
    {
        public int Id { get; set; }
    }
}
