using Microsoft.AspNetCore.Identity;

namespace countdownR.API.Entities;

public class AppUser : IdentityUser
{
    public List<Countdown> Countdowns { get; set; } = new List<Countdown>();
}
