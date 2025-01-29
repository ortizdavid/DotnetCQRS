using DotnetCQRS.Models;

namespace DotnetCQRS.Repositories.Categories;

public class CategoryCommandRepository : ICommandRepository<Category>
{
    private readonly AppDbContext _context;

    public CategoryCommandRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Category model)
    {
        try
        {
            await _context.Categories.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task CreateBatchAsync(IEnumerable<Category> model)
    {
        using (var transaction = _context.Database.BeginTransaction())  
        {
            try
            {
                await _context.AddRangeAsync(model);
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

    public async Task DeleteAsync(Category model)
    {
        try
        {
            _context.Categories.Remove(model);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task UpdateAsync(Category model)
    {
        try
        {
            _context.Categories.Update(model);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}