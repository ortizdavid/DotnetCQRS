using System.Linq.Expressions;
using DotnetCQRS.Exceptions;
using DotnetCQRS.Helpers;
using DotnetCQRS.Models;
using DotnetCQRS.Repositories.Users;

namespace DotnetCQRS.Core.Users.Queries
{
    public class ListUsersHandler : IQueryManyHandler<UserData, ListUsersQuery>
    {
        private readonly UserQueryRepository _repository;
        private readonly IHttpContextAccessor _httpContext;

        public ListUsersHandler(UserQueryRepository repository, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _httpContext = httpContext;
        }

        public async Task<Pagination<UserData>> Handle(ListUsersQuery query)
        {
            if (query is null)
            {
                throw new BadRequestException("PageSize and PageIndex cannot be null");
            }
            var count = await _repository.CountAsync();
            if (count == 0)
            {
                throw new NotFoundException("No users found");
            }
            var users = await _repository.GetAllDataAsync(query.PageSize, query.PageIndex);	
            var pagination = new Pagination<UserData>(users, count, query.PageIndex, query.PageSize, _httpContext);
            return pagination;
        }
    }
}