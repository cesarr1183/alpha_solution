using AlphaApp.DataClasses;
using AlphaApp.DataRepository;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaApp.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Product entity)
        {
            entity.Created = entity.Modified = DateTime.UtcNow;
            string sql = "INSERT INTO Products (Name, Description, Created, Modified) VALUES (@Name, @Description, @Created, @Modified)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                return await connection.ExecuteAsync(sql, entity);
            }
        }

        public async Task DeleteAsync(int id)
        {
            string sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                _ = await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            string sql = "SELECT * FROM Products";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                return (await connection.QueryAsync<Product>(sql)).ToList();
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                return await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
            }
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            entity.Modified = DateTime.UtcNow;
            string sql = "UPDATE Products SET Name = @Name, Description = @Description, Created = @Created, Modified = @Modified WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                return await connection.ExecuteAsync(sql, entity);
            }
        }
    }
}
