using Microsoft.Data.SqlClient;
using DotnetCQRS.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;

namespace DotnetCQRS.Repositories.Products
{
    public class ProductQueryRepository : IQueryRepository<Product>
    {
        private readonly AppDbContext _context;
        private IDbConnection _dapper;

        public ProductQueryRepository(AppDbContext context, IDbConnection dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<bool> ExistsRecordAsync(string? field, string? value)
        {
            var sql = $"SELECT COUNT(*) FROM Products WHERE {field} = @Value";
            var count = await _dapper.ExecuteScalarAsync<int>(sql, new {Value = value});
            return count > 0;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int limit, int offset)
        {
            return await _context.Products
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product?> GetByUniqueIdAsync(Guid uniqueId)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.UniqueId == uniqueId);
        }

        public async Task<IEnumerable<ProductData>> GetAllDataAsync(int limit, int offset)
        {
            var sql = "SELECT * FROM ViewProductData ORDER BY CreatedAt DESC " +
                    $"OFFSET {offset} ROWS FETCH NEXT {limit} ROWS ONLY;";
            return  await _dapper.QueryAsync<ProductData>(sql);
        }

        public async Task<ProductData> GetDataByIdAsync(int id)
        {
            var sql = "SELECT * FROM ViewProductData WHERE ProductId = @Id";
            return await _dapper.QueryFirstAsync<ProductData>(sql, new {Id = id});
        }

        public async Task<ProductData> GetDataByUniqueIdAsync(Guid uniqueId)
        {
            var sql = "SELECT * FROM ViewProductData WHERE UniqueId = @UniqueId";
            return await _dapper.QueryFirstAsync<ProductData>(sql, new {UniqueId = uniqueId});
        }
    }
}