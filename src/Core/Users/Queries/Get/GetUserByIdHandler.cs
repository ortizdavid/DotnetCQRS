using DotnetCQRS.Models;

namespace DotnetCQRS.Core.Users.Queries
{
    public class GetUserByIdHandler : IQueryOneHandler<User, GetUserByIdQuery>
    {
        public Task<User> Handle(GetUserByIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}