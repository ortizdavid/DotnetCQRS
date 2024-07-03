using System.Data.SqlClient;
using DotnetCQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCQRS.Repositories.Products
{
    public class ProductQueryRepository : IQueryRepository<Product>
    {
        private readonly AppDbContext _context;

        public ProductQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<bool> ExistsRecordAsync(string? field, string? value)
        {
            if (string.IsNullOrWhiteSpace(field) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Field and value must have value", nameof(field) ?? nameof(value));
            }
            var validFields = new HashSet<string>{"Code"};
            if (!validFields.Contains(field))
            {
                throw new ArgumentException("Invalid field", nameof(field));
            }
            var fieldParam = new SqlParameter("Field", field);
            var valueParam = new SqlParameter("Value", value);
            return await _context.Products
                .FromSqlRaw($"SELECT 1 FROM Products @Field = @Value", fieldParam, valueParam)
                .AnyAsync();
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
    }
}