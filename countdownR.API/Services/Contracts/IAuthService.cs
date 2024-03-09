using countdownR.API.DTOs.Account;

namespace countdownR.API.Services.Contracts;

public interface IAuthService
{
    Task<(int, string)> Register(RegisterAccountRequestDTO registerAccountRequestDTO, string role);
    Task<(int, string)> Login(LoginAccountRequestDTO loginAccountRequestDTO);
}
