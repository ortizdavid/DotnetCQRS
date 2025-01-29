
using DotnetCQRS.Exceptions;
using DotnetCQRS.Helpers;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Categories;

namespace DotnetCQRS.Core.Categories.Queries;

public class ListCategoriesHandler : IQueryManyHandler<Category, ListCategoriesQuery>
{
    private readonly CategoryQueryRepository _repository;
    private readonly IHttpContextAccessor _httpContext;

    public ListCategoriesHandler(CategoryQueryRepository repository, IHttpContextAccessor httpContext)
    {
        _repository = repository;
        _httpContext = httpContext;
    }
    
    public async Task<Pagination<Category>> Handle(ListCategoriesQuery query)
    {
        if (query is null)
        {
            throw new BadRequestException("PageSize and PageIndex cannot be null");
        }
        var count = await _repository.CountAsync();
        if (count == 0)
        {
            throw new NotFoundException("No categories found");
        }
        var categories = await _repository.GetAllAsync(query.PageSize, query.PageIndex);
        var pagination = new Pagination<Category>(categories, count, query.PageIndex, query.PageSize, _httpContext);
        return pagination;
    }
}