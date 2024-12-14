namespace Modernize.Application
{
    public class LoginUserCommand : ICommand<LoginSuccessDto>
    {
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
