namespace Core.Entities;

public class Charge
{
    public int ChargeId { get; set; }
    public int CardId { get; set; }
    public decimal Amount { get; set; }
    public decimal AvailableCredit { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }

    public Card Card { get; set; } = null!;
}