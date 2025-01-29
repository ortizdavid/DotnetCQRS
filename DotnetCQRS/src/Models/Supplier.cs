using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Models;

public class Supplier : IModel
{
    [Key]
    public int SupplierId { get; set; }

    [Required]
    public string? SupplierName { get; set; }

    [Required]
    public string? IdentificationNumber { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? PrimaryPhone { get; set; }

    public string? SecondaryPhone { get; set; }

    public string? Address { get; set; }
    
    [Required]
    public Guid UniqueId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; } 
}