namespace countdownR.API.DTOs.Countdown;

public record UpdateCountdownRequestDTO(DateTime Date, string Title, string? Subtitle, string? DigitsColor, string? TilesColor, string? BackgroundImageUrl, byte[]? BackgroundImage);