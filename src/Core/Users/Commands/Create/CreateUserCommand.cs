using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Users.Commands
{
    public class CreateUserCommand
    {
        [Required]
        public int UserRole { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "UserName must be between 3 and 150 characters.")]
        public string? UserName { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 250 characters.")]
        public string? Password { get; set; }

        [StringLength(100, ErrorMessage = "Image path must be up to 100 characters.")]
        public string? Image { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [StringLength(200, ErrorMessage = "Token must be up to 200 characters.")]
        public string? Token { get; set; }
    }
}
