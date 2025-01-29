namespace DotnetCQRS.Core.Users.Queries;

public class ListUsersQuery
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}