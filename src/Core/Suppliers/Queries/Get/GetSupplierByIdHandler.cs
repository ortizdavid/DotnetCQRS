using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Suppliers;

namespace DotnetCQRS.Core.Suppliers.Queries
{
    public class GetSupplierByIdHandler : IQueryOneHandler<Supplier, GetSupplierByIdQuery>
    {
        private readonly SupplierQueryRepository _repository;

        public GetSupplierByIdHandler(SupplierQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Supplier> Handle(GetSupplierByIdQuery query)
        {
            if (query is null)
            {
                throw new BadRequestException("SupplierId cannot be null");
            }
            var supplier = await _repository.GetByIdAsync(query.SupplierId);
            if (supplier is null)
            {
                throw new NotFoundException("Supplier not found");
            }
            return supplier;
        }
    }
}