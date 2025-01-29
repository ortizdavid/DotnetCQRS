using System.ComponentModel.DataAnnotations;
using DotnetCQRS.Core;

namespace DotnetCQRS.Core.Products.Commands;

public class CreateProductCommand 
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage="CategoryId must be a positive integer.")]
    public int CategoryId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage="SupplierId must be a positive integer.")]
    public int SupplierId { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 100 characters.")]
    public string? ProductName { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Product code must be between 3 and 30 characters.")]
    public string? Code { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than zero.")]
    public decimal UnitPrice { get; set; }

    [StringLength(150, ErrorMessage = "Description can't be longer than 150 characters.")]
    public string? Description { get; set; }
}