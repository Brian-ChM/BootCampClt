namespace Core.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime FechaDeNac { get; set; }

    // Relations
    public List<Account> Accounts { get; set; } = [];
    public List<Card> Cards { get; set; } = [];
}
