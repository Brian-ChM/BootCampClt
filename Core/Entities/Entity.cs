namespace Core.Entities;

public class Entity
{
    public int Id { get; set; }
    public string EntityName { get; set; } = string.Empty;

    // Relaciones
    public List<Product> Products { get; set; } = null!;
    public List<CustomerEntity> CustomerEntities { get; set; } = [];
}
