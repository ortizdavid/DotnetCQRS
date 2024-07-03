using DotnetCQRS.Helpers;
using DotnetCQRS.Models;

namespace DotnetCQRS.Core.Users.Queries
{
    public class ListUsersHandler : IQueryManyHandler<User, ListUsersQuery>
    {
        public Task<Pagination<User>> Handle(ListUsersQuery query)
        {
            throw new NotImplementedException();
        }
    }
}