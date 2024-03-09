using countdownR.API.Common;
using countdownR.API.DTOs.Account;
using countdownR.API.Entities;
using countdownR.API.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace countdownR.API.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
    }

    public async Task<(int, string)> Login(LoginAccountRequestDTO loginAccountRequestDTO)
    {
        var user = await _userManager.FindByNameAsync(loginAccountRequestDTO.Username);

        if (user is null)
        {
            return (0, "Invalid username!");
        }

        if (!await _userManager.CheckPasswordAsync(user, loginAccountRequestDTO.Password))
        {
            return (0, "Invalid password!");
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        string token = _tokenService.CreateToken(authClaims);
        return (1, token);
    }

    public async Task<(int, string)> Register(RegisterAccountRequestDTO registerAccountRequestDTO, string role)
    {
        var userExists = await _userManager.FindByNameAsync(registerAccountRequestDTO.Username);
        if (!(userExists is null))
        {
            return (0, "User already exists!");
        }

        AppUser appUser = new AppUser()
        {
            Email = registerAccountRequestDTO.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = registerAccountRequestDTO.Username,
        };

        var createUserResult = await _userManager.CreateAsync(appUser, registerAccountRequestDTO.Password);
        if (!createUserResult.Succeeded)
        {
            return (0, "User creation failed! Please check user details and try again!");
        }

        if (!await _roleManager.RoleExistsAsync(role))
        {
            await _roleManager.CreateAsync(new IdentityRole(role));
        }

        if (await _roleManager.RoleExistsAsync(UserRoles.User))
        {
            await _userManager.AddToRoleAsync(appUser, role);
        }

        return (1, "User created successfully!");
    }
}