using countdownR.API.Entities;
using System.Security.Claims;

namespace countdownR.API.Services.Contracts;

public interface ITokenService
{
    string CreateToken(IEnumerable<Claim> claims);
}
