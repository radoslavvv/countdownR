using AutoMapper;
using countdownR.API.Common;
using countdownR.API.DTOs.Account;
using countdownR.API.Entities;
using countdownR.API.Services.Contracts;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace countdownR.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;

    public AuthenticationController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, IMapper mapper, IAuthService authService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _mapper = mapper;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginAccountRequestDTO loginAccountRequestDTO,
        [FromServices] IValidator<LoginAccountRequestDTO> validator)
    {
        ValidationResult validationResult = validator.Validate(loginAccountRequestDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var (status, message) = await _authService.Login(loginAccountRequestDTO);

            if (status == 0)
            {
                return BadRequest(message);
            }
            else
            {
                return Ok(message);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterAccountRequestDTO registerAccountRequestDTO,
        [FromServices] IValidator<RegisterAccountRequestDTO> validator)
    {
        ValidationResult validationResult = validator.Validate(registerAccountRequestDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var (status, message) = await _authService.Register(registerAccountRequestDTO, UserRoles.User);

            if (status == 0)
            {
                return BadRequest(message);
            }

            return CreatedAtAction(nameof(Register), message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}
