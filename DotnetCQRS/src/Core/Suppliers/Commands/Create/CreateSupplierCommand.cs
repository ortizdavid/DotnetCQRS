using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Suppliers.Commands;

public class CreateSupplierCommand
{
    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "SupplierName must be between 3 and 100 characters.")]
    public string? SupplierName { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "IdentificationNumber must be between 3 and 30 characters.")]
    public string? IdentificationNumber { get; set; }

    [Required]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 150 characters.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "PrimaryPhone must be between 3 and 20 characters.")]
    [Phone(ErrorMessage = "Invalid phone number.")]
    public string? PrimaryPhone { get; set; }

    [StringLength(20, MinimumLength = 3, ErrorMessage = "SecondaryPhone must be between 3 and 20 characters.")]
    [Phone(ErrorMessage = "Invalid phone number.")]
    public string? SecondaryPhone { get; set; }

    [Required]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 150 characters.")]
    public string? Address { get; set; }
}
