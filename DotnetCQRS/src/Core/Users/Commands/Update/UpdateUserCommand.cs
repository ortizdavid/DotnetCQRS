using System.ComponentModel.DataAnnotations;
using DotnetCQRS.Models;

namespace DotnetCQRS.Core.Users.Commands;

public class UpdateUserCommand
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public UserRole UserRole { get; set; }
}