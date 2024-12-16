namespace Modernize.Application
{
    /// <summary>
    /// Query of getting user information
    /// </summary>
    public class GetUserInfoQuery : IQuery<UserDto>
    {
        public string UserId { get; set; } = null!;
    }
}
