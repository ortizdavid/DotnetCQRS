using DotnetCQRS.Models;

namespace DotnetCQRS.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(User? model)
        {
            throw new NotImplementedException();
        }

        public Task CreateBatchAsync(IEnumerable<User> model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User? model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsRecordAsync(string? field, string? value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByUniqueIdAsync(Guid uniqueId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User? model)
        {
            throw new NotImplementedException();
        }
    }
}