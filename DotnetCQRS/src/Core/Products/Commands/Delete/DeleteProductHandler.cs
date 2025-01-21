using DotnetCQRS.Core;
using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Products;

namespace DotnetCQRS.Core.Products.Commands
{
    public class DeleteProductHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly ProductCommandRepository _commandRepo;
        private readonly ProductQueryRepository _queryRepo;

        public DeleteProductHandler(ProductCommandRepository commandRepo, ProductQueryRepository queryRepo)
        {
            _commandRepo = commandRepo;
            _queryRepo = queryRepo;
        } 
        public async Task Handle(DeleteProductCommand command)
        {
            try
            {
                if (command is null)
                {
                    throw new BadRequestException("Delete command cannot be null");
                }
                var product = await _queryRepo.GetByIdAsync(command.ProductId);
                if (product is null)
                {
                    throw new NotFoundException("Product not found");
                }
                await _commandRepo.DeleteAsync(product);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}