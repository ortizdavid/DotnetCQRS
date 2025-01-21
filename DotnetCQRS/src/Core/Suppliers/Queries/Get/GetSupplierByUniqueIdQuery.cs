using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Suppliers.Queries
{
    public class GetSupplierByUniqueIdQuery
    {
        [Required]
        public Guid UniqueId { get; set; }
    }
}