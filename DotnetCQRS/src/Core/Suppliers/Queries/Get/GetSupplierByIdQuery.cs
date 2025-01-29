using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Suppliers.Queries;

public class GetSupplierByIdQuery
{
    [Required]
    public int SupplierId { get; set; }
}