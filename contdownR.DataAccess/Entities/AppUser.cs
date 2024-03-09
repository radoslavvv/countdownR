using Microsoft.AspNetCore.Identity;

namespace contdownR.DataAccess.Entities;

public class AppUser : IdentityUser
{
    public List<Countdown> Countdowns { get; set; } = new List<Countdown>();
}
