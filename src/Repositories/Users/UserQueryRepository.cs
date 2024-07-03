using System.Data.SqlClient;
using DotnetCQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCQRS.Repositories.Users
{
    public class UserQueryRepository : IQueryRepository<User>
    {
        private readonly AppDbContext _context;

        public UserQueryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<bool> ExistsRecordAsync(string? field, string? value)
        {
            if (string.IsNullOrWhiteSpace(field) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Field and value must have a value", nameof(field) ?? nameof(value));
            }
            var validFields = new HashSet<string>{"UserName"};
            if (!validFields.Contains(field))
            {
                throw new ArgumentException("Invalid field", nameof(field));
            }
            var fieldParam = new SqlParameter("Field", field);
            var ValueParam = new SqlParameter("Value", value);
            return await _context.Users
                .FromSqlRaw($"SELECT 1 FROM Users WHERE @Field = @Value", fieldParam, ValueParam)
                .AnyAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync(int limit, int offset)
        {
            return await _context.Users
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByUniqueIdAsync(Guid uniqueId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UniqueId == uniqueId);
        }

        public async Task<User?> GetByUserNameAsync(string? userName)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == userName);
        }


    }
}