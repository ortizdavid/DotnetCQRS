using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Suppliers.Commands
{
    public class DeleteSupplierCommand
    {
        [Required]
        public int SupplierId { get; set; }
    }
}