namespace Core.DTOs.Charges;

public class ChargeDTO
{
    public int ChargeId { get; set; }
    public int CardId { get; set; }
    public decimal Amount { get; set; }
    public decimal AvailableCredit { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date {  get; set; }
}