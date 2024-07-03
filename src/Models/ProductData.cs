namespace DotnetCQRS.Models
{
    public class ProductData
    {
        public int ProductId { get; }
        public Guid UniqueId { get; }
        public string? ProductName { get; }
        public string? Code { get; }
        public decimal UnitPrice { get; }
        public string? Description { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public int CategoryId { get; }
        public string? CategoryName { get; }
        public int SupplierId { get; }
        public string? SupplierName { get; }
    }
}