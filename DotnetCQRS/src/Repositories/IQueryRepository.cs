namespace DotnetCQRS.Repositories
{
    public interface IQueryRepository<T>  where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync(int limit, int offset);
        public Task<T?> GetByIdAsync(int id);
        public Task<T?> GetByUniqueIdAsync(Guid uniqueId);
        public Task<bool> ExistsRecordAsync(string? field, string? value);
        public Task<int> CountAsync();
    }
}