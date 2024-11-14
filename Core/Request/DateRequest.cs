namespace Core.Request;

public class DateRequest
{
    public DateOnly Start { get; set; }  = new DateOnly(1970, 01, 01);
    public DateOnly End { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
}
