namespace Modernize.Application
{
    public interface IUserService<LoginDto> : IBaseService<UserCreationDto, UserUpdateDto, UserDto, Guid>
    {
        Task<string> Login(LoginDto loginDto);
    }
}
