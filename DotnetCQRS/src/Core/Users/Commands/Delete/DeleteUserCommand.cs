using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Users.Commands;

public class DeleteUserCommand
{
    [Required]
    public int UserId { get; set; }
}