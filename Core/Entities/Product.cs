namespace Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }

    // Relaciones
    public int EntityId { get; set; }
    public Entity Entity { get; set; } = null!;
}
