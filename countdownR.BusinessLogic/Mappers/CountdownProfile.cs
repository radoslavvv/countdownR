using AutoMapper;
using countdownR.API.DTOs.Countdown;
using countdownR.API.Entities;

namespace countdownR.BusinessLogic.Mappers;

public class CountdownProfile : Profile
{
    public CountdownProfile()
    {
        CreateMap<Countdown, CountdownDTO>()
            .ReverseMap();

        CreateMap<Countdown, CreateCountdownRequestDTO>()
            .ReverseMap();

        CreateMap<Countdown, UpdateCountdownRequestDTO>()
            .ReverseMap();
    }
}
