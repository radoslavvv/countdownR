using countdownR.API.DTOs.Account;
using countdownR.API.DTOs.Countdown;
using countdownR.API.Validators.Account;
using countdownR.API.Validators.Countdown;
using FluentValidation;
using System.Runtime.CompilerServices;

namespace countdownR.API.Extensions;

public static class ValidatorExtensions
{
    public static IServiceCollection AddRequestsValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateCountdownRequestDTO>, CreateCountdownRequestValidator>();
        services.AddScoped<IValidator<UpdateCountdownRequestDTO>, UpdateCountdownRequestValidator>();
        services.AddScoped<IValidator<RegisterAccountRequestDTO>, RegisterAccountRequestValidator>();
        services.AddScoped<IValidator<LoginAccountRequestDTO>, LoginAccountRequestValidator>();

        return services;
    }
}
