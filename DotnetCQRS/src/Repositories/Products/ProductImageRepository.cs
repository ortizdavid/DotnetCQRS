using DotnetCQRS.Models;

namespace DotnetCQRS.Repositories.Products;

public class ProductImageRepository : ICommandRepository<ProductImage>
{
    private readonly AppDbContext _context;

    public ProductImageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(ProductImage model)
    {
        try
        {
            await _context.ProductImages.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task CreateBatchAsync(IEnumerable<ProductImage> models)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                await _context.ProductImages.AddRangeAsync(models);
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

    public async Task DeleteAsync(ProductImage model)
    {
        try
        {
            _context.ProductImages.Remove(model);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task UpdateAsync(ProductImage model)
    {
        try
        {
            _context.ProductImages.Update(model);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}