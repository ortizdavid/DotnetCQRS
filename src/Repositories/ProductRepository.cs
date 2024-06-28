using DotnetCQRS.Models;

namespace DotnetCQRS.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Product? model)
        {
            throw new NotImplementedException();
        }

        public Task CreateBatchAsync(IEnumerable<Product> model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product? model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsRecordAsync(string? field, string? value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public Task<Product?> GetByUniqueIdAsync(Guid uniqueId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product? model)
        {
            throw new NotImplementedException();
        }
    }
}