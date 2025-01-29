using DotnetCQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCQRS.Repositories.Users;

public class UserCommandRepository : ICommandRepository<User>
{
    private readonly AppDbContext _context;

    public UserCommandRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(User model)
    {
        try
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task CreateBatchAsync(IEnumerable<User> models)
    {
       using (var transaction = _context.Database.BeginTransaction())
       {
            try
            {
                await _context.Users.AddRangeAsync(models);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (System.Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
       }
    }

    public async Task DeleteAsync(User model)
    {
        try
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task UpdateAsync(User model)
    {
        try
        {
            _context.Users.Update(model);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}