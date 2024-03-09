namespace contdownR.DataAccess.Entities;

public class Countdown
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Subtitle { get; set; }

    public string? DigitsColor { get; set; }

    public string? TilesColor { get; set; }

    public string? BackgroundImageUrl { get; set; }

    public byte[]? BackgroundImage { get; set; }

    public string? AppUserId { get; set; }

    public AppUser? AppUser { get; set; }
}
