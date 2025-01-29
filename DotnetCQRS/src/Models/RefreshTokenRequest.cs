using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Models;

public class RefreshTokenRequest
{
    [Required]
    public string? RefreshToken { get; set; }
}