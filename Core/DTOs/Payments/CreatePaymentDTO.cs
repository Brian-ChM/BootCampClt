namespace Core.DTOs.Payments;

public class CreatePaymentDTO
{
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}