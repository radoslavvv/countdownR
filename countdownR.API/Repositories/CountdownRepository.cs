using countdownR.API.Data;
using countdownR.API.DTOs.Countdown;
using countdownR.API.Entities;
using countdownR.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace countdownR.API.Repositories;

public class CountdownRepository : ICountdownRepository
{
    private readonly ApplicationDbContext _context;

    public CountdownRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Countdown> CreateCountdownAsync(Countdown countdown, string? userId)
    {
        countdown.AppUserId = userId;

        await _context.Countdowns.AddAsync(countdown);
        await _context.SaveChangesAsync();

        return countdown;
    }

    public async Task<Countdown?> DeleteCountdownAsync(int id)
    {
        Countdown? countdown = await _context.Countdowns.FirstOrDefaultAsync(c => c.Id == id);

        if (countdown is null)
        {
            return null;
        }

        _context.Countdowns.Remove(countdown);
        await _context.SaveChangesAsync();

        return countdown;
    }

    public async Task<Countdown?> GetCountdownByIdAsync(int id)
    {
        return await _context.Countdowns.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Countdown>> GetCountdownsAsync()
    {
        return await _context.Countdowns.ToListAsync();
    }

    public async Task<IEnumerable<Countdown>> GetUserCountdownsAsync(string? userId)
    {
        IQueryable<Countdown> countdowns = _context.Countdowns;
        if (userId is not null)
        {
            countdowns = countdowns.Where(c=>c.AppUserId == userId);
        }

        return await countdowns.ToListAsync();
    }

    public async Task<Countdown?> UpdateCountdownAsync(int id, UpdateCountdownRequestDTO updateCountdownRequestDTO, string? userId)
    {
        Countdown? countdown = await _context.Countdowns.FirstOrDefaultAsync(c => c.Id == id);

        if (countdown is null)
        {
            return null;
        }

        countdown.Title = updateCountdownRequestDTO.Title;
        countdown.Date = updateCountdownRequestDTO.Date;
        countdown.Subtitle = updateCountdownRequestDTO.Subtitle;
        countdown.DigitsColor = updateCountdownRequestDTO.DigitsColor;
        countdown.TilesColor = updateCountdownRequestDTO.TilesColor;
        countdown.BackgroundImageUrl = updateCountdownRequestDTO.BackgroundImageUrl;
        countdown.BackgroundImage = updateCountdownRequestDTO.BackgroundImage;

        await _context.SaveChangesAsync();

        return countdown;
    }
}
