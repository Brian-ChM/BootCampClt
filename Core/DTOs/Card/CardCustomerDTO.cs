namespace Core.DTOs.Card;

public class CardCustomerDTO
{
    public int CardId { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public decimal CreditLimit { get; set; }
    public decimal AvailableCredit { get; set; }
}