using contdownR.DataAccess.DTOs.Countdown;
using contdownR.DataAccess.Entities;

namespace countdownR.API.Repositories.Contracts;

public interface ICountdownRepository
{
    Task<IEnumerable<Countdown>> GetCountdownsAsync();

    Task<Countdown?> GetCountdownByIdAsync(int id);

    Task<Countdown> CreateCountdownAsync(Countdown countdown);

    Task<Countdown?> UpdateCountdownAsync(int id, UpdateCountdownRequestDTO updateCountdownRequestDTO);

    Task<Countdown?> DeleteCountdownAsync(int id);
}
