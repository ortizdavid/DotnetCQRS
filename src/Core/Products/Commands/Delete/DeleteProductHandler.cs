using DotnetCQRS.Core;
using DotnetCQRS.Repositories;

namespace DotnetCQRS.Core.Products.Commands
{
    public class DeleteProductHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly ProductRepository _repository;

        public DeleteProductHandler(ProductRepository repository)
        {
            _repository = repository;
        } 
        public Task Handle(DeleteProductCommand command)
        {
            throw new NotImplementedException();
        }
    }
}