using DotnetCQRS.Models;

namespace DotnetCQRS.Core;

public interface IQueryOneHandler<T, Q> where T : IModel
{
    public Task<T> Handle(Q query);
}