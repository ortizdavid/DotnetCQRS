using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Categories;

namespace DotnetCQRS.Core.Categories.Queries;

public class GetCategoryByUniqueIdHandler : IQueryOneHandler<Category, GetCategoryByUniqueIdQuery>
{
    private readonly CategoryQueryRepository _repository;
    
    public GetCategoryByUniqueIdHandler(CategoryQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category> Handle(GetCategoryByUniqueIdQuery query)
    {
        if (query is null)
        {
            throw new BadRequestException("Category UniqueId cannot be null");
        }
        var category = await _repository.GetByUniqueIdAsync(query.UniqueId);
        if (category is null)
        {
            throw new NotFoundException("Category not found");
        }
        return category;
    }
}