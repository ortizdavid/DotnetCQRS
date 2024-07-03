
using DotnetCQRS.Models;

namespace DotnetCQRS.Repositories.Categories
{
    public class CategoryQueryRepository : IQueryRepository<Category>
    {
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsRecordAsync(string? field, string? value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByUniqueIdAsync(Guid uniqueId)
        {
            throw new NotImplementedException();
        }
    }
}