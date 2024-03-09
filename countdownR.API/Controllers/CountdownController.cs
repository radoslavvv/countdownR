using AutoMapper;
using countdownR.API.DTOs.Countdown;
using countdownR.API.Entities;
using countdownR.API.Repositories.Contracts;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace countdownR.API.Controllers;

[ApiController]
[Route("api/countdowns")]
public class CountdownController : ControllerBase
{
    private readonly ICountdownRepository _repository;
    private readonly IMapper _mapper;

    public CountdownController(ICountdownRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetCountdowns()
    {
        IEnumerable<Countdown> countdowns = await _repository.GetCountdownsAsync();

        return Ok(countdowns);
    }

    [AllowAnonymous]
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserCountdowns(string userId)
    {
        IEnumerable<Countdown> countdowns = await _repository.GetUserCountdownsAsync(userId);

        return Ok(countdowns);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCountdownById([FromRoute] int id)
    {
        Countdown? countdown = await _repository.GetCountdownByIdAsync(id);

        if (countdown is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CountdownDTO>(countdown));
    }

    [AllowAnonymous]
    [HttpPost("create")]
    public async Task<IActionResult> CreateCountdown([FromBody] CreateCountdownRequestDTO createCountdownRequestDTO,
        [FromServices] IValidator<CreateCountdownRequestDTO> validator)
    {
        ValidationResult validationResult = validator.Validate(createCountdownRequestDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        Countdown? createdCountdown = await _repository.CreateCountdownAsync(_mapper.Map<Countdown>(createCountdownRequestDTO), userId);

        return CreatedAtAction(nameof(GetCountdownById), new { id = createdCountdown.Id }, _mapper.Map<CountdownDTO>(createdCountdown));
    }

    [AllowAnonymous]
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateCountdown([FromRoute] int id, [FromBody] UpdateCountdownRequestDTO updateCountdownRequestDTO,
         [FromServices] IValidator<UpdateCountdownRequestDTO> validator)
    {
        ValidationResult validationResult = validator.Validate(updateCountdownRequestDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        Countdown? countdown = await _repository.GetCountdownByIdAsync(id);

        if (countdown is null)
        {
            return NotFound();
        }

        if(countdown.AppUserId is not null && countdown.AppUserId != userId)
        {
            return Unauthorized();
        }

        Countdown? updatedCountdown = await _repository.UpdateCountdownAsync(id, updateCountdownRequestDTO, userId);

        return Ok(_mapper.Map<CountdownDTO>(updatedCountdown));
    }

    [AllowAnonymous]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCountdown([FromRoute] int id)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        Countdown? countdown = await _repository.GetCountdownByIdAsync(id);

        if (countdown is null)
        {
            return NotFound();
        }

        if (countdown.AppUserId is not null && countdown.AppUserId != userId)
        {
            return Unauthorized();
        }

        Countdown? deletedCountdown = await _repository.DeleteCountdownAsync(id);

        return NoContent();
    }
}
