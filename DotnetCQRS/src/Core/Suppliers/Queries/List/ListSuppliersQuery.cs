using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Suppliers.Queries
{
    public class ListSuppliersQuery
    {
        [Required]
        public int PageIndex { get; set; } = 0;

        [Required]
        public int PageSize { get; set; } = 10;
    }
}