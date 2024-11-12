namespace Core.DTOs.Account;

public class AccountCustomerDetailedDTO
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? FechaDeNac { get; set; }
}
