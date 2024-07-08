using DotnetCQRS.Exceptions;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Users;

namespace DotnetCQRS.Core.Users.Queries
{
    public class GetUserByUniqueIdHandler : IQueryOneHandler<UserData, GetUserByUniqueIdQuery>
    {
        private readonly UserQueryRepository _repository;

        public GetUserByUniqueIdHandler(UserQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserData> Handle(GetUserByUniqueIdQuery query)
        {
           if (query is null)
           {
                throw new BadRequestException("UniqueId cannot be null");
           }
           var user = await _repository.GetDataByUniqueIdAsync(query.UniqueId);
           if (user is null)
           {
                throw new NotFoundException("User not found");
           }
           return user;
        }
    }
}