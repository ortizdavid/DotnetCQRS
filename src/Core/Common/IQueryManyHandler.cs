using DotnetCQRS.Models;

namespace DotnetCQRS.Core
{
    public interface IQueryManyHandler<T, Q> where T : IModel
    {
        public Task<IEnumerable<T>> Handle(Q query);
    }
}