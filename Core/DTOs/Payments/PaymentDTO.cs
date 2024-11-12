namespace Core.DTOs.Payments;

public class PaymentDTO
{
    public int Id { get; set; }
    public int CardId { get; set; }
    public decimal Amount { get; set; }
    public decimal AvailableCredit { get; set; }
    public DateTime Date { get; set; }
}