using DotnetCQRS.Models;

namespace DotnetCQRS.Core.Suppliers.Queries
{
    public class GetSupplierByUniqueIdHandler : IQueryOneHandler<Supplier, GetSupplierByUniqueIdQuery>
    {
        public Task<Supplier> Handle(GetSupplierByUniqueIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}