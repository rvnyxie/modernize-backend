namespace Modernize.Application
{
    public class LoginUserCommand : ICommand<LoginSuccessCredentialsDto>
    {
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
