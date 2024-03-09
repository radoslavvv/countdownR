namespace countdownR.DataAccess.DTOs.Countdown;

public record CreateCountdownRequestDTO(DateTime Date, string Title, string? Subtitle, string? DigitsColor, string? TilesColor, string? BackgroundImageUrl, byte[]? BackgroundImage);