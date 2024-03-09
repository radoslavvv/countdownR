using countdownR.API.DTOs.Countdown;
using countdownR.API.Entities;

namespace countdownR.API.Repositories.Contracts;

public interface ICountdownRepository
{
    Task<IEnumerable<Countdown>> GetCountdownsAsync();

    Task<IEnumerable<Countdown>> GetUserCountdownsAsync(string? userId);

    Task<Countdown?> GetCountdownByIdAsync(int id);

    Task<Countdown> CreateCountdownAsync(Countdown countdown, string? userId);

    Task<Countdown?> UpdateCountdownAsync(int id, UpdateCountdownRequestDTO updateCountdownRequestDTO, string? userId);

    Task<Countdown?> DeleteCountdownAsync(int id);
}
