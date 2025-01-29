using DotnetCQRS.Core;
using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Categories;

namespace DotnetCQRS.Core.Categories.Commands;

public class DeleteCategoryHandler : ICommandHandler<DeleteCategoryCommand>
{
    private readonly CategoryCommandRepository _commandRepo;
    private readonly CategoryQueryRepository _queryRepo;

    public DeleteCategoryHandler(CategoryCommandRepository commandRepo, CategoryQueryRepository queryRepo)
    {
        _commandRepo = commandRepo;
        _queryRepo = queryRepo;
    } 
    public async Task Handle(DeleteCategoryCommand command)
    {
        try
        {
            if (command is null)
            {
                throw new BadRequestException("Delete command cannot be null");
            }
            var category = await _queryRepo.GetByIdAsync(command.CategoryId);
            if (category is null)
            {
                throw new NotFoundException("Category not found");
            }
            await _commandRepo.DeleteAsync(category);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}