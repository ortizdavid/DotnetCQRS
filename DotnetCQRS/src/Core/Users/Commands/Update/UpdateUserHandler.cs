using DotnetCQRS.Exceptions;
using DotnetCQRS.Helpers;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Users;

namespace DotnetCQRS.Core.Users.Commands;

public class UpdateUserHandler : ICommandHandler<UpdateUserCommand>
{
    private readonly UserCommandRepository _commandRepo;
    private readonly UserQueryRepository _queryRepo;

    public UpdateUserHandler(UserCommandRepository commandRepo, UserQueryRepository queryRepo)  
    {
        _commandRepo = commandRepo;
        _queryRepo = queryRepo;
    }

    public async Task Handle(UpdateUserCommand command)
    {
        try
        {
            if (command is null)
            {
                throw new BadRequestException("Update user command cannot be null");
            }
            var user = await _queryRepo.GetByIdAsync(command.UserId);
            if (user is null)
            {
                throw new NotFoundException("User not found");
            }
            user.UserRole = command.UserRole;
            user.Token = Encryption.GenerateRandomToken(16);
            user.UpdatedAt = DateTime.UtcNow;
            await _commandRepo.UpdateAsync(user);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}