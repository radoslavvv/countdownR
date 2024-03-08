using countdownR.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace countdownR.DataAccess.Identity;
public class ApplicationUser : IdentityUser
{
    public List<Countdown> Countdowns { get; set; } = new List<Countdown>();
}
