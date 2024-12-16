namespace Modernize.Domain
{
    /// <summary>
    /// Interface of user readonly repository
    /// </summary>
    public interface IUserReadonlyRepository : IBaseReadonlyRepository<User, Guid>
    {
        /// <summary>
        /// Asynchronously get current authenticated user
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>Current authenticated user</returns>
        Task<User> GetCurrentAuthenticatedUserAsync(string userId);
    }
}
