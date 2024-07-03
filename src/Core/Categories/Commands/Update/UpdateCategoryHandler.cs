using DotnetCQRS.Core;
using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Categories;

namespace DotnetCQRS.Core.Categories.Commands
{
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
                var product = await _queryRepo.GetByIdAsync(command.CategoryId);
                if (product is  null)
                {
                    throw new NotFoundException($"Category with id '{command.CategoryId}' does not exists");
                }
                product.CategoryName = command.CategoryName;
                product.Description = command.Description;
                await _commandRepo.UpdateAsync(product);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}