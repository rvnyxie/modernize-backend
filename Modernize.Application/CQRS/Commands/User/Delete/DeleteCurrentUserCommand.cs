namespace Modernize.Application
{
    /// <summary>
    /// Command of deleting current user
    /// </summary>
    public class DeleteCurrentUserCommand : ICommand<int>
    {
        public Guid Id { get; set; }
    }
}
