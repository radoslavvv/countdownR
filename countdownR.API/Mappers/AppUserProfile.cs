using AutoMapper;
using countdownR.API.DTOs.Account;
using countdownR.API.DTOs.Countdown;
using countdownR.API.Entities;

namespace countdownR.API.Mappers;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUser, AccountDTO>()
           .ReverseMap();

        CreateMap<AppUser, LoginAccountRequestDTO>()
           .ReverseMap();

        CreateMap<AppUser, RegisterAccountRequestDTO>()
           .ReverseMap();

        CreateMap<RegisterAccountRequestDTO, LoginAccountRequestDTO>()
           .ReverseMap();
    }
}
