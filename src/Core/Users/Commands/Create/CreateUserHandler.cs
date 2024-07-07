using DotnetCQRS.Exceptions;
using DotnetCQRS.Helpers;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Users;

namespace DotnetCQRS.Core.Users.Commands
{
    public class CreateUserHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly UserCommandRepository _commandRepo;
        private readonly UserQueryRepository _queryRepo;

        public CreateUserHandler(UserCommandRepository commandRepo, UserQueryRepository queryRepo)  
        {
            _commandRepo = commandRepo;
            _queryRepo = queryRepo;
        }

        public async Task Handle(CreateUserCommand command)
        {
            try
            {
                if (command is null)
                {
                    throw new BadRequestException("Create user command cannot be null");
                }
                if (await _queryRepo.ExistsRecordAsync("UserName", command.UserName))
                {
                    throw new ConflictException($"UserName '{command.UserName}' already exists");
                }
                var user = new User()
                {
                    UserRole = command.UserRole,
                    UserName = command.UserName,
                    Password = PasswordHelper.Hash(command.Password),
                    Image = "",
                    Token = Encryption.GenerateRandomToken(16),
                    UniqueId = Encryption.GenerateUUID(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                await _commandRepo.CreateAsync(user);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}