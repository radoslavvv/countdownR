using countdownR.API.DTOs.Account;
using countdownR.API.DTOs.Countdown;
using FluentValidation;

namespace countdownR.API.Validators.Account;

public class LoginAccountRequestValidator : AbstractValidator<LoginAccountRequestDTO>
{
    public LoginAccountRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username cannot be empty!");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty!")
            .MinimumLength(12)
            .WithMessage("Password cannot be less than 12 characters!");
    }
}
