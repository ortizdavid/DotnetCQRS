using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Users.Commands
{
    public class UpdateUserCommand
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int UserRole { get; set; }
    }
}