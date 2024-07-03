using DotnetCQRS.Helpers;
using DotnetCQRS.Models;

namespace DotnetCQRS.Core
{
    public interface IQueryManyHandler<T, Q> where T : IModel
    {
        public Task<Pagination<T>> Handle(Q query);
    }
}