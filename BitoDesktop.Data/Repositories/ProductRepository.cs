using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using BitoDesktop.Data.IRepositories;
using BitoDesktop.Domain.Entities.Products;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace BitoDesktop.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {
        }

        public async Task<int> AddAsync(Product entity)
        {
            var sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price);";
            using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=MarketDb;Username=postgres;Password=muham1812;"))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id;";
            using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=MarketDb;Username=postgres;Password=muham1812;"))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Products;";
            using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=MarketDb;Username=postgres;Password=muham1812;"))
            {
                connection.Open();
                var result = await connection.QueryAsync<Product>(sql);
                return result.ToList();
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id;";
            using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=MarketDb;Username=postgres;Password=muham1812;"))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            var sql = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id";
            using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=MarketDb;Username=postgres;Password=muham1812;"))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
