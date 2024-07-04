using DotnetCQRS.Models;

namespace DotnetCQRS.Repositories.Suppliers
{
    public class SupplierCommandRepository : ICommandRepository<Supplier>
    {
        private readonly AppDbContext _context;

        public SupplierCommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Supplier model)
        {
            try
            {
                await _context.Suppliers.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task CreateBatchAsync(IEnumerable<Supplier> models)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.Suppliers.AddRangeAsync(models);
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

        public async Task DeleteAsync(Supplier model)
        {
            try
            {
                _context.Suppliers.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Supplier model)
        {
            try
            {
                _context.Suppliers.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}