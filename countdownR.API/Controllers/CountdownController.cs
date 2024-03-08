using AutoMapper;
using countdownR.API.DTOs.Countdown;
using countdownR.API.Entities;
using countdownR.API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public async Task<IActionResult> GetCountdowns()
    {
        IEnumerable<Countdown> countdowns = await _repository.GetCountdownsAsync();

        return Ok(countdowns);
    }

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

    [HttpPost("create")]
    public async Task<IActionResult> CreateCountdown([FromBody] CreateCountdownRequestDTO createCountdownRequestDTO)
    {
        Countdown? createdCountdown = await _repository.CreateCountdownAsync(_mapper.Map<Countdown>(createCountdownRequestDTO));

        return CreatedAtAction(nameof(GetCountdownById), new { id = createdCountdown.Id }, _mapper.Map<CountdownDTO>(createdCountdown));
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateCountdown([FromRoute] int id, [FromBody] UpdateCountdownRequestDTO updateCountdownRequestDTO)
    {
        Countdown? updatedCountdown = await _repository.UpdateCountdownAsync(id, updateCountdownRequestDTO);

        if (updatedCountdown is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CountdownDTO>(updatedCountdown));
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCountdown([FromRoute] int id)
    {
        Countdown? deletedCountdown = await _repository.DeleteCountdownAsync(id);

        if (deletedCountdown is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
