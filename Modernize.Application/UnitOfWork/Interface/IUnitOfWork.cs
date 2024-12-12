namespace Modernize.Application
{
    /// <summary>
    /// Unit Of Work interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Save changes made to DB
        /// </summary>
        /// <returns>Number of rows affected</returns>
        Task<int> SaveChangesAsync();
    }
}
