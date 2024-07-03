using DotnetCQRS.Helpers;
using DotnetCQRS.Models;

namespace DotnetCQRS.Core.Suppliers.Queries
{
    public class ListSuppliersHandler : IQueryManyHandler<Supplier, ListSuppliersQuery>
    {
        public Task<Pagination<Supplier>> Handle(ListSuppliersQuery query)
        {
            throw new NotImplementedException();
        }
    }
}