namespace DotnetCQRS.Models;

public interface IModel
{
    public Guid UniqueId { get; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
}