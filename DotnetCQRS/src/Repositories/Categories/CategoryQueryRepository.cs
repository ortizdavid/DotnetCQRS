using System.Data;
using Dapper;
using DotnetCQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCQRS.Repositories.Categories
{
    public class CategoryQueryRepository : IQueryRepository<Category>
    {
        private readonly AppDbContext _context;
        private IDbConnection _dapper;

        public CategoryQueryRepository(AppDbContext context, IDbConnection dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Categories.CountAsync();
        }

        public async Task<bool> ExistsRecordAsync(string? field, string? value)
        {
            var sql = $"SELECT COUNT(*) FROM Categories WHERE {field} = @Value";
            var count = await _dapper.ExecuteScalarAsync<int>(sql, new {Value = value});
            return count > 0;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(int limit, int offset)
        {
            return await _context.Categories
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category?> GetByUniqueIdAsync(Guid uniqueId)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.UniqueId == uniqueId);
        }
    }
}