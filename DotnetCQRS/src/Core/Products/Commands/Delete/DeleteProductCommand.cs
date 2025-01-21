using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Products.Commands
{
    public class DeleteProductCommand 
    {
        [Required]
        public int ProductId { get; set; }
    }
}