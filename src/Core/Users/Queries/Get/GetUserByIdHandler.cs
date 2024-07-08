using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Users;

namespace DotnetCQRS.Core.Users.Queries
{
    public class GetUserByIdHandler : IQueryOneHandler<UserData, GetUserByIdQuery>
    {
        private readonly UserQueryRepository _repository;

        public GetUserByIdHandler(UserQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserData> Handle(GetUserByIdQuery query)
        {
            if (query is null)
            {
                throw new BadRequestException("UserId cannot be null");
            }
            var user = await _repository.GetDataByIdAsync(query.UserId);
            if (user is null)
            {
                throw new NotFoundException("User not found");
            }
            return user;
        }
    }
}