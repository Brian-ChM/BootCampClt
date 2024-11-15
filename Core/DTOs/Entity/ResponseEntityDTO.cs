using Core.DTOs.Customer;
using Core.DTOs.Product;

namespace Core.DTOs.Entity;

public class ResponseEntityDTO
{
    public string Entidad { get; set; } = string.Empty;
    public List<ResponseProductDTO> Products { get; set; } = new();
}
