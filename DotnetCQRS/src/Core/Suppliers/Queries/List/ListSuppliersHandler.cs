using DotnetCQRS.Exceptions;
using DotnetCQRS.Helpers;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Suppliers;

namespace DotnetCQRS.Core.Suppliers.Queries;

public class ListSuppliersHandler : IQueryManyHandler<Supplier, ListSuppliersQuery>
{
    private readonly SupplierQueryRepository _repository;
    private readonly IHttpContextAccessor _httpContext;

    public ListSuppliersHandler(SupplierQueryRepository repository, IHttpContextAccessor httpContext)
    {
        _repository = repository;
        _httpContext = httpContext;
    }

    public async Task<Pagination<Supplier>> Handle(ListSuppliersQuery query)
    {
        if (query is null)
        {
            throw new BadRequestException("PageSize and PageIndex cannot be null");
        }
        var count = await _repository.CountAsync();
        if (count == 0)
        {
            throw new NotFoundException("No suppliers found");
        }
        var suppliers = await _repository.GetAllAsync(query.PageSize, query.PageSize);
        var pagination = new Pagination<Supplier>(suppliers, count, query.PageIndex, query.PageSize, _httpContext);
        return pagination;
    }
}