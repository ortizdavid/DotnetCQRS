using Dapper;
using DotnetCQRS.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DotnetCQRS.Repositories.Users;

public class UserQueryRepository : IQueryRepository<User>
{
    private readonly AppDbContext _context;
    private IDbConnection _dapper;

    public UserQueryRepository(AppDbContext context, IDbConnection dapper)
    {
        _context = context;
        _dapper = dapper;
    }

    public async Task<int> CountAsync()
    {
        return await _context.Users.CountAsync();
    }

    public async Task<bool> ExistsRecordAsync(string? field, string? value)
    {
        var sql = $"SELECT COUNT(*) FROM Users WHERE {field} = @Value";
        var count = await _dapper.ExecuteScalarAsync<int>(sql, new {Value = value});
        return count > 0;
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

    public async Task<IEnumerable<UserData>> GetAllDataAsync(int limit, int offset)
    {
        var sql = "SELECT * FROM ViewUserData ORDER BY CreatedAt DESC " +
                $"OFFSET {offset} ROWS FETCH NEXT {limit} ROWS ONLY;";
        return  await _dapper.QueryAsync<UserData>(sql);
    }

    public async Task<UserData> GetDataByIdAsync(int id)
    {
        var sql = "SELECT * FROM ViewUserData WHERE UserId = @Id";
        return await _dapper.QueryFirstAsync<UserData>(sql, new {Id = id});
    }

    public async Task<UserData> GetDataByUniqueIdAsync(Guid uniqueId)
    {
        var sql = "SELECT * FROM ViewUserData WHERE UniqueId = @UniqueId";
        return await _dapper.QueryFirstAsync<UserData>(sql, new {UniqueId = uniqueId});
    }
}