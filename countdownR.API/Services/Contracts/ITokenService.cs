using countdownR.API.Entities;

namespace countdownR.API.Services.Contracts;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
