using System.Data.SqlClient;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotnetCQRS.Repositories.Suppliers
{
    public class SupplierQueryRepository : IQueryRepository<Supplier>
    {
        private readonly AppDbContext _context;

        public SupplierQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Suppliers
                .CountAsync();
        }

        public async Task<bool> ExistsRecordAsync(string? field, string? value)
        {
            if (string.IsNullOrWhiteSpace(field) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Field and value must have a value", nameof(field) ?? nameof(value));
            }
            var validFields = new HashSet<string>{"IdentificationNumber", "PrimaryPhone", "SecondaryPhone", "Email"};
            if (!validFields.Contains(field))
            {
                throw new ArgumentException("Invalid field", nameof(field));
            }
            var fieldParam = new SqlParameter("Field", field);
            var ValueParam = new SqlParameter("Value", value);
            return await _context.Suppliers
                .FromSqlRaw($"SELECT 1 FROM Suppliers WHERE @Field = @Value", fieldParam, ValueParam)
                .AnyAsync();
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