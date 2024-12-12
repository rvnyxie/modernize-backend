namespace Modernize.Application
{
    /// <summary>
    /// Command handler interface
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        /// <summary>
        /// Handle defined type of command
        /// </summary>
        /// <param name="command">Command need to be handled</param>
        /// <returns></returns>
        Task HandleAsync(TCommand command);
    }

    public interface ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        /// <summary>
        /// Handle defined type of command
        /// </summary>
        /// <param name="command">Command need to be handled</param>
        /// <returns>Response with defined type</returns>
        Task<TResponse> HandleAsync(TCommand command);
    }
}
