using DotnetCQRS.Core;
using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Categories;

namespace DotnetCQRS.Core.Categories.Commands;

public class UpdateCategoryHandler : ICommandHandler<UpdateCategoryCommand>
{
   
    private readonly CategoryCommandRepository _commandRepo;
    private readonly CategoryQueryRepository _queryRepo;

    public UpdateCategoryHandler(CategoryCommandRepository commandRepo, CategoryQueryRepository queryRepo)
    {
        _commandRepo = commandRepo;
        _queryRepo = queryRepo;
    }

    public async Task Handle(UpdateCategoryCommand command)
    {
        try
        {
            if (command is null)
            {
                throw new BadRequestException("Update command cannot be null");
            }
            var category = await _queryRepo.GetByIdAsync(command.CategoryId);
            if (category is  null)
            {
                throw new NotFoundException($"Category with id '{command.CategoryId}' does not exists");
            }
            category.CategoryName = command.CategoryName;
            category.Description = command.Description;
            category.UpdatedAt = DateTime.UtcNow;
            await _commandRepo.UpdateAsync(category);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}