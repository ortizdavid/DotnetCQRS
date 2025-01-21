using DotnetCQRS.Models;

namespace DotnetCQRS.Repositories.Products
{
    public class ProductCommandRepository : ICommandRepository<Product>
    {
        private readonly AppDbContext _context;

        public ProductCommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product model)
        {
            try
            {
                await _context.Products.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            { 
                throw;
            }
        }

        public async Task CreateBatchAsync(IEnumerable<Product> model)
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

        public async Task DeleteAsync(Product model)
        {
            try
            {
                _context.Products.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Product model)
        {
            try
            {
                _context.Products.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}