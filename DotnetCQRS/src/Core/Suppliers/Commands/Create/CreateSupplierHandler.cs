using DotnetCQRS.Exceptions;
using DotnetCQRS.Helpers;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Suppliers;

namespace DotnetCQRS.Core.Suppliers.Commands;

public class CreateSupplierHandler : ICommandHandler<CreateSupplierCommand>
{
    private readonly SupplierCommandRepository _commandRepo;
    private readonly SupplierQueryRepository _queryRepo;

    public CreateSupplierHandler(SupplierCommandRepository commandRepo, SupplierQueryRepository queryRepo)  
    {
        _commandRepo = commandRepo;
        _queryRepo = queryRepo;
    }

    public async Task Handle(CreateSupplierCommand command)
    {
        try
        {
            if (command is null)
            {
                throw new BadRequestException("Create user command cannot be null");
            }
            if (await _queryRepo.ExistsRecordAsync("IdentificationNumber", command.IdentificationNumber))
            {
                throw new ConflictException($"Supplier identification '{command.IdentificationNumber}' already exists");
            }
            if (await _queryRepo.ExistsRecordAsync("PrimaryPhone", command.PrimaryPhone))
            {
                throw new ConflictException($"Supplier Primary Phone '{command.PrimaryPhone}' already exists");
            }
             if (await _queryRepo.ExistsRecordAsync("SecondaryPhone", command.SecondaryPhone))
            {
                throw new ConflictException($"Supplier Secondary Phone '{command.SecondaryPhone}' already exists");
            }
            if (await _queryRepo.ExistsRecordAsync("Email", command.Email))
            {
                throw new ConflictException($"Supplier email '{command.Email}' already exists");
            }
            var supplier = new Supplier()
            {
                SupplierName = command.SupplierName,
                IdentificationNumber = command.IdentificationNumber,
                PrimaryPhone = command.PrimaryPhone,
                SecondaryPhone = command.SecondaryPhone,
                Email = command.Email,                    
                Address = command.Address,
                UniqueId = Encryption.GenerateUUID(),
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };
            await _commandRepo.CreateAsync(supplier);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}