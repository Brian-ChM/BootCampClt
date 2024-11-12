namespace Core.DTOs.Card;

public class DetailedCardDTO
{
    public int CardId { get; set; }
    public int CustomerId { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal AvailableCredit {  get; set; }
    public float InterestRate { get; set; }
}