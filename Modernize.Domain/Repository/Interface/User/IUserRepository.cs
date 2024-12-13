namespace Modernize.Domain
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
        Task<string> Login(string email, string password);
    }
}
