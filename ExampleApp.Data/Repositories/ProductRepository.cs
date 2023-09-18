using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ExampleApp.Data.IRepositories;
using ExampleApp.Domain.Entities.Products;
using System.Data.SqlClient;

namespace ExampleApp.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration configuration;
        public ProductRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Product entity)
        {
            var sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price);";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("MarketDb")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id;";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("MarketDb")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Products;";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("MarketDb")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Product>(sql);
                return result.ToList();
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id;";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("MarketDb")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            var sql = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("MarketDb")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
