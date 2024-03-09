using countdownR.API.DTOs.Account;
using countdownR.API.DTOs.Countdown;
using FluentValidation;

namespace countdownR.API.Validators.Account;

public class LoginAccountRequestValidator : AbstractValidator<LoginAccountRequestDTO>
{
    public LoginAccountRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}
