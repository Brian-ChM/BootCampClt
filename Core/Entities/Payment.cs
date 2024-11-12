namespace Core.Entities;

public class Payment
{
    public int PaymentId { get; set; }
    public int CardId { get; set; }
    public decimal Amount { get; set; }
    public decimal AvailableCredit { get; set; }
    public DateTime Date {  get; set; }

    public Card Card { get; set; } = null!;
}