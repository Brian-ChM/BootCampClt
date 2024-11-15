namespace Core.DTOs.Product;

public class CreateProductDTO
{
    public int EntityId { get; set; }
    public string Producto { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
}
