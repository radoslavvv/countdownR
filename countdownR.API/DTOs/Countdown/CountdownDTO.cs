namespace countdownR.API.DTOs.Countdown;

public record CountdownDTO(int Id, DateTime Date, string Title, string? Subtitle, string? DigitsColor, string? TilesColor, string? BackgroundImageUrl, byte[]? BackgroundImage);

