using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Users.Queries;

public class GetUserByUniqueIdQuery
{
    [Required]
    public Guid UniqueId { get; set; }
}