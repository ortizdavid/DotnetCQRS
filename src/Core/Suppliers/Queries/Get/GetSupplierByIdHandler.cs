using DotnetCQRS.Models;

namespace DotnetCQRS.Core.Suppliers.Queries
{
    public class GetSupplierByIdHandler : IQueryOneHandler<Supplier, GetSupplierByIdQuery>
    {
        public Task<Supplier> Handle(GetSupplierByIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}