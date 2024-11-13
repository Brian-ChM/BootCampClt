namespace Core.DTOs.Card;

public class ResponseCardDto
{
    public int CardId { get; set; }
    public int CustomerId { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public string Status { get; set; } = string.Empty;
}
