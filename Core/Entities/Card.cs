namespace Core.Entities;

public class Card
{
    public int CardId { get; set; }
    public int CustomerId { get; set; }
    public string CardType { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public decimal CreditLimit { get; set; }
    public decimal AvailableCredit { get; set; }
    public string Status { get; set; } = string.Empty;
    public float InterestRate { get; set; }


    public Customer Customer { get; set; } = null!;
    public List<Charge> Charges { get; set; } = [];
    public List<Payment> Payments { get; set; } = [];

}
