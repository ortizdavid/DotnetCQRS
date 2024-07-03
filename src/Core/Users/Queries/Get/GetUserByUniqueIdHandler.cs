using DotnetCQRS.Models;

namespace DotnetCQRS.Core.Users.Queries
{
    public class GetUserByUniqueIdHandler : IQueryOneHandler<User, GetUserByUniqueIdQuery>
    {
        public Task<User> Handle(GetUserByUniqueIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}