using countdownR.API.DTOs.Account;
using FluentValidation;

namespace countdownR.API.Validators.Account;

public class RegisterAccountRequestValidator : AbstractValidator<RegisterAccountRequestDTO>
{
    public RegisterAccountRequestValidator()
    {
        RuleFor(x => x.Username)
           .NotEmpty();

        RuleFor(x => x.Email)
            .EmailAddress()
           .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}
