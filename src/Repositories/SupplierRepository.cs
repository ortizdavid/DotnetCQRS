using DotnetCQRS.Repositories;

namespace DotnetCQRS.Models
{
    public class SupplierRepository : IRepository<Supplier>
    {
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Supplier? model)
        {
            throw new NotImplementedException();
        }

        public Task CreateBatchAsync(IEnumerable<Supplier> model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Supplier? model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsRecordAsync(string? field, string? value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Supplier>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Supplier?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier?> GetByUniqueIdAsync(Guid uniqueId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Supplier? model)
        {
            throw new NotImplementedException();
        }
    }
}