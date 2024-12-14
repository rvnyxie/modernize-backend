namespace Modernize.Application
{
    public interface IUserService : IBaseService<UserCreationDto, UserUpdateDto, UserDto, Guid>
    {
        Task<string> Login(LoginDto loginDto);
    }
}
