using Core.DTOs.Account;

namespace Core.DTOs.Customer;

public class CustomerDTO
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? FechaDeNac { get; set; }
    public List<CustomerAccountDetailedDTO>? Accounts { get; set; }
}
