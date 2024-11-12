namespace Core.DTOs.Card;

public class CreateCardDTO
{
    public int CustomerId { get; set; }
    public string CardType { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public DateTime ExpirationDate { get; set; }
    public float InterestRate { get; set; }
}