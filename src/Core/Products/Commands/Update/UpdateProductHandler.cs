using DotnetCQRS.Core;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories;

namespace DotnetCQRS.Core.Products.Commands
{
    public class UpdateProductHandler : ICommandHandler<UpdateProductCommand>
    {
       
        private readonly ProductRepository _repository;

        public UpdateProductHandler(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductCommand command)
        {
            try
            {
                var product = await _repository.GetByIdAsync(command.ProductId);
                await _repository.UpdateAsync(product);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}