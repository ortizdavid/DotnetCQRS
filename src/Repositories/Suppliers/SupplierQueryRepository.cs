using Microsoft.Data.SqlClient;
using DotnetCQRS.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;

namespace DotnetCQRS.Repositories.Suppliers
{
    public class SupplierQueryRepository : IQueryRepository<Supplier>
    {
        private readonly AppDbContext _context;
        private readonly IDbConnection _dapper;

        public SupplierQueryRepository(AppDbContext context, IDbConnection dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Suppliers
                .CountAsync();
        }

        public async Task<bool> ExistsRecordAsync(string? field, string? value)
        {
            var sql = $"SELECT COUNT(*) FROM Suppliers WHERE {field} = @Value";
            var count = await _dapper.ExecuteScalarAsync<int>(sql, new {Value = value});
            return count > 0;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync(int limit, int offset)
        {
            return await _context.Suppliers
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return await _context.Suppliers
                .FindAsync(id);
        }

        public async Task<Supplier?> GetByUniqueIdAsync(Guid uniqueId)
        {
            return await _context.Suppliers
                .FirstOrDefaultAsync(u => u.UniqueId == uniqueId);
        }
    }
}