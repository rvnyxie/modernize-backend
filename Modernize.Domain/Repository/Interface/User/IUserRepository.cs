namespace Modernize.Domain
{
    /// <summary>
    /// Interface for user repository
    /// </summary>
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
        /// <summary>
        /// Login with credentials
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="password">User password</param>
        /// <returns>Access token</returns>
        Task<string> Login(string email, string password);

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user">User information</param>
        /// <param name="password">User password</param>
        /// <returns>Create user</returns>
        Task<User> CreateUser(User user, string password);
    }
}
