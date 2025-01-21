
using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Categories;

namespace DotnetCQRS.Core.Categories.Queries
{
    public class GetCategoryByIdHandler : IQueryOneHandler<Category, GetCategoryByIdQuery>
    {
        private readonly CategoryQueryRepository _repository;
        
        public GetCategoryByIdHandler(CategoryQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery query)
        {
            if (query is null)
            {
                throw new BadRequestException("Category UniqueId cannot be null");
            }
            var category = await _repository.GetByIdAsync(query.CategoryId);
            if (category is null)
            {
                throw new NotFoundException("Category not found");
            }
            return category;
        }
    }
}