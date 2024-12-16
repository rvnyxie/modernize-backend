namespace Modernize.Application
{
    /// <summary>
    /// Interface of user readonly service
    /// </summary>
    public interface IUserReadonlyService : IBaseReadonlyService<UserDto, Guid>
    {
        /// <summary>
        /// Asynchronously get current authenticated user
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>Current authenticated user DTO</returns>
        Task<UserDto> GetCurrentAuthenticatedUserAsync(string userId);
    }
}
