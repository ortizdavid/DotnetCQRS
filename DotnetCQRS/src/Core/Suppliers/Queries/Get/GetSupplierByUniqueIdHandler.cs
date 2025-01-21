using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Suppliers;

namespace DotnetCQRS.Core.Suppliers.Queries
{
    public class GetSupplierByUniqueIdHandler : IQueryOneHandler<Supplier, GetSupplierByUniqueIdQuery>
    {
        private readonly SupplierQueryRepository _repository;

        public GetSupplierByUniqueIdHandler(SupplierQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Supplier> Handle(GetSupplierByUniqueIdQuery query)
        {
            if (query is null)
            {
                throw new BadRequestException("UniqueId cannot be null");
            }
            var supplier = await _repository.GetByUniqueIdAsync(query.UniqueId);
            if (supplier is null)
            {
                throw new NotFoundException("Supplier cannot be null");
            }
            return supplier;
        }
    }
}