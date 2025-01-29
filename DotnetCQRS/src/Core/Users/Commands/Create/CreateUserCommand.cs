using System.ComponentModel.DataAnnotations;
using DotnetCQRS.Models;

namespace DotnetCQRS.Core.Users.Commands;

public class CreateUserCommand
{
    [Required]
    public UserRole UserRole { get; set; }

    [Required]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "UserName must be between 3 and 150 characters.")]
    public string? UserName { get; set; }

    [Required]
    [StringLength(250, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 250 characters.")]
    public string? Password { get; set; }
}
