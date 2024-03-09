using countdownR.API.Entities;

namespace countdownR.BusinessLogic.Services.Contracts;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
