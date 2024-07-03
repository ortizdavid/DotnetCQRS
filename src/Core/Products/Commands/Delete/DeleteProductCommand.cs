
using System.ComponentModel.DataAnnotations;
using DotnetCQRS.Core;
using DotnetCQRS.Repositories.Products;

namespace DotnetCQRS.Core.Products.Commands
{
    public class DeleteProductCommand 
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage="ProductId must be a positive integer.")]
        public int ProductId { get; set; }
    }
}