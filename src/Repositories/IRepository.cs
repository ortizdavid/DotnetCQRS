namespace DotnetCQRS.Repositories
{
    public interface IRepository<T>  where T : class
    {
        public Task CreateAsync(T? model);
        public Task CreateBatchAsync(IEnumerable<T> model);
        public Task UpdateAsync(T? model);
        public Task DeleteAsync(T? model);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task<T?> GetByUniqueIdAsync(Guid uniqueId);
        public Task<bool> ExistsRecordAsync(string? field, string? value);
        public Task<int> CountAsync();
    }
}