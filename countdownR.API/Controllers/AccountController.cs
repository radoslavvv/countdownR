using countdownR.API.DTOs.Account;
using countdownR.API.Entities;
using countdownR.API.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace countdownR.API.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;

    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginAccountRequestDTO loginAccountRequestDTO)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginAccountRequestDTO.Username.ToLower());

        if (user is null)
        {
            return Unauthorized("Invalid username");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginAccountRequestDTO.Password, false);

        if (!result.Succeeded)
        {
            return Unauthorized("Incorrect password!");
        }

        return Ok(new AccountDTO(user.UserName, user.Email, _tokenService.CreateToken(user)));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterAccountRequestDTO registerAccountRequestDTO)
    {
        try
        {
            AppUser appUser = new AppUser
            {
                UserName = registerAccountRequestDTO.Username,
                Email = registerAccountRequestDTO.Email,
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerAccountRequestDTO.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                if (roleResult.Succeeded)
                {
                    return Ok(new AccountDTO(appUser.UserName, appUser.Email, _tokenService.CreateToken(appUser)));
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}
