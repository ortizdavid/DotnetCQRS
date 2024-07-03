namespace DotnetCQRS.Repositories
{
    public interface ICommandRepository<T>  where T : class
    {
        public Task CreateAsync(T model);
        public Task CreateBatchAsync(IEnumerable<T> models);
        public Task UpdateAsync(T model);
        public Task DeleteAsync(T model);
    }
}