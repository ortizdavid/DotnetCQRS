using DotnetCQRS.Core;
using DotnetCQRS.Exceptions;
using DotnetCQRS.Helpers;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Products;

namespace DotnetCQRS.Core.Products.Commands;

public class CreateProductHandler : ICommandHandler<CreateProductCommand>
{
    private readonly ProductCommandRepository _commandRepo;
    private readonly ProductQueryRepository _queryRepo;

    public CreateProductHandler(ProductCommandRepository commandRepo, ProductQueryRepository queryRepo)
    {
        _commandRepo = commandRepo;
        _queryRepo = queryRepo;
    }

    public async Task Handle(CreateProductCommand command)
    {
        try
        {
            if (command is null)
            {
                throw new BadRequestException("Create product command cannot be null");
            }
            if (await _queryRepo.ExistsRecordAsync("Code", command.Code))
            {
                throw new ConflictException($"Product code '{command.Code}' already exists");
            }  
            var product = new Product()
            {
                CategoryId = command.CategoryId,
                SupplierId = command.SupplierId,
                ProductName = command.ProductName,
                Code = command.Code,
                UnitPrice = command.UnitPrice,
                Description = command.Description,
                UniqueId = Encryption.GenerateUUID(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _commandRepo.CreateAsync(product);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}