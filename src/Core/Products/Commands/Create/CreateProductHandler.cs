using DotnetCQRS.Core;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories;

namespace DotnetCQRS.Core.Products.Commands
{
    public class CreateProductHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly ProductRepository _repository;

        public CreateProductHandler(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProductCommand command)
        {
            try
            {
                var product = new Product()
                {
                    
                };
                await _repository.CreateAsync(product);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}