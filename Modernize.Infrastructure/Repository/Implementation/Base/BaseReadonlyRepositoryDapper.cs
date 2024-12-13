using Dapper;
using Modernize.Domain;
using MySqlConnector;

namespace Modernize.Infrastructure
{
    /// <summary>
    /// Base readonly repository implementation using Dapper
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TId">Entity ID type</typeparam>
    public abstract class BaseReadonlyRepositoryDapper<TEntity, TId> : IBaseReadonlyRepository<TEntity, TId>
    {
        private readonly string _connectionString = "Server=localhost;Database=ModernizeDb;User=root;Password=123;";

        public virtual string TableName { get; set; } = typeof(TEntity).Name + "s";

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            // Initialize connection
            var dbConnection = new MySqlConnection(_connectionString);

            // Refine query parameters

            // Compose sql query
            var sqlQuery = $"SELECT * FROM {TableName}";

            // Get data
            var entities = await dbConnection.QueryAsync<TEntity>(sqlQuery);

            // Return value
            return entities;
        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            // Initialize connection
            var dbConnection = new MySqlConnection(_connectionString);

            // Refine query parameters
            // Compose sql query
            var sqlQuery = $"SELECT * FROM {TableName} WHERE Id = @Id";

            // Get data
            var entity = await dbConnection.QueryFirstOrDefaultAsync<TEntity>(sqlQuery, new { Id = id });

            // Return value
            return entity;
        }
    }
}
