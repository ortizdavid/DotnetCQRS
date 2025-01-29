using DotnetCQRS.Core;
using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Products;

namespace DotnetCQRS.Core.Products.Commands;

public class UpdateProductHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly ProductCommandRepository _commandRepo;
    private readonly ProductQueryRepository _queryRepo;

    public UpdateProductHandler(ProductCommandRepository commandRepo, ProductQueryRepository queryRepo)
    {
        _commandRepo = commandRepo;
        _queryRepo = queryRepo;
    }

    public async Task Handle(UpdateProductCommand command)
    {
        try
        {
            if (command is null)
            {
                throw new BadRequestException("Update command cannot be null");
            }
            var product = await _queryRepo.GetByIdAsync(command.ProductId);
            if (product is  null)
            {
                throw new NotFoundException($"Product with id '{command.ProductId}' does not exists");
            }
            product.SupplierId = command.SupplierId;
            product.CategoryId = command.CategoryId;
            product.ProductName = command.ProductName;
            product.Description = command.Description;
            product.UnitPrice = command.UnitPrice;
            product.UpdatedAt = DateTime.UtcNow;
            await _commandRepo.UpdateAsync(product);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}