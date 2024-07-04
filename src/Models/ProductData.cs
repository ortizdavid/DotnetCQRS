namespace DotnetCQRS.Models
{
    public class ProductData : IModel
    {
        public int ProductId { get; }
        public Guid UniqueId { get; set; }
        public string? ProductName { get; }
        public string? Code { get; }
        public decimal UnitPrice { get; }
        public string? Description { get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CategoryId { get; }
        public string? CategoryName { get; }
        public int SupplierId { get; }
        public string? SupplierName { get; }
    }
}