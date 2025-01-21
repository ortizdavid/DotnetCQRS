using DotnetCQRS.Exceptions;
using DotnetCQRS.Repositories.Suppliers;

namespace DotnetCQRS.Core.Suppliers.Commands
{
    public class UpdateSupplierHandler : ICommandHandler<UpdateSupplierCommand>
    {
        private readonly SupplierCommandRepository _commandRepo;
        private readonly SupplierQueryRepository _queryRepo;

        public UpdateSupplierHandler(SupplierCommandRepository commandRepo, SupplierQueryRepository queryRepo)
        {
            _commandRepo = commandRepo;
            _queryRepo = queryRepo;	
        }

        public async Task Handle(UpdateSupplierCommand command)
        {
            try
            {
                if (command is null)
                {
                    throw new BadRequestException("Update supplier command cannot be null");
                }
                var supplier = await _queryRepo.GetByIdAsync(command.SupplierId);
                if (supplier is null)
                {
                    throw new NotFoundException("Supplie not found");
                }
                supplier.SupplierName = command.SupplierName;
                supplier.IdentificationNumber = command.IdentificationNumber;
                supplier.PrimaryPhone = command.PrimaryPhone;
                supplier.SecondaryPhone = command.SecondaryPhone;
                supplier.Email = command.Email;
                supplier.Address = command.Address;
                supplier.UpdatedAt = DateTime.UtcNow;
                await _commandRepo.UpdateAsync(supplier);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}