using DotnetCQRS.Core;
using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Categories;

namespace DotnetCQRS.Core.Categories.Commands
{
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
                var product = await _queryRepo.GetByIdAsync(command.CategoryId);
                if (product is null)
                {
                    throw new NotFoundException("Category not found");
                }
                await _commandRepo.DeleteAsync(product);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}