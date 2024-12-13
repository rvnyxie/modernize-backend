namespace Modernize.Application
{
    internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserDto>
    {
        public Task<UserDto> HandleAsync(CreateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
