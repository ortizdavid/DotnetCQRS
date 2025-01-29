namespace DotnetCQRS.Core;

public interface ICommandHandler<T> where T : class
{
    public Task Handle(T command);
}