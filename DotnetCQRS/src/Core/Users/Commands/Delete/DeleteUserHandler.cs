using DotnetCQRS.Exceptions;
using DotnetCQRS.Repositories.Users;

namespace DotnetCQRS.Core.Users.Commands;

public class DeleteUserHandler : ICommandHandler<DeleteUserCommand>
{
    private readonly UserCommandRepository _commandRepo;
    private readonly UserQueryRepository _queryRepo;

    public DeleteUserHandler(UserCommandRepository commandRepo, UserQueryRepository queryRepo) 
    {
        _commandRepo = commandRepo;
        _queryRepo = queryRepo;
    }

    public async Task Handle(DeleteUserCommand command)
    {
        try
        {
            if (command is null)
            {
                throw new BadRequestException("UserId cannot be null");
            }
            var user = await _queryRepo.GetByIdAsync(command.UserId);
            if (user is null)
            {
                throw new NotFoundException("User not found");
            }
            await _commandRepo.DeleteAsync(user);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}