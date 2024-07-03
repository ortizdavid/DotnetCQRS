using DotnetCQRS.Core;
using DotnetCQRS.Exceptions;
using DotnetCQRS.Helpers;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Categories;

namespace DotnetCQRS.Core.Categories.Commands
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly CategoryCommandRepository _commandRepo;
        private readonly CategoryQueryRepository _queryRepo;

        public CreateCategoryHandler(CategoryCommandRepository commandRepo, CategoryQueryRepository queryRepo)
        {
            _commandRepo = commandRepo;
            _queryRepo = queryRepo;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            try
            {
                if (command is null)
                {
                    throw new BadRequestException("Create category command cannot be null");
                }
                if (await _queryRepo.ExistsRecordAsync("CategoryName", command.CategoryName))
                {
                    throw new ConflictException($"Category name '{command.CategoryName}' already exists");
                }  
                var category = new Category()
                {
                    CategoryName = command.CategoryName,
                    Description = command.Description,
                };
                await _commandRepo.CreateAsync(category);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}