using DotnetCQRS.Exceptions;
using DotnetCQRS.Repositories.Suppliers;

namespace DotnetCQRS.Core.Suppliers.Commands;

public class DeleteSupplierHandler : ICommandHandler<DeleteSupplierCommand>
{
    private readonly SupplierCommandRepository _commandRepo;
    private readonly SupplierQueryRepository _queryRepo;

    public DeleteSupplierHandler(SupplierCommandRepository commandRepo, SupplierQueryRepository queryRepo)
    {
        _commandRepo = commandRepo;
        _queryRepo = queryRepo;
    }

    public async Task Handle(DeleteSupplierCommand command)
    {
        try
        {
            if (command is null)
            {
                throw new BadRequestException("SupplierId cannot be null");
            }
            var supplier = await _queryRepo.GetByIdAsync(command.SupplierId);
            if (supplier is null)
            {
                throw new NotFoundException("Supplier not found");
            }
            await _commandRepo.DeleteAsync(supplier);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}