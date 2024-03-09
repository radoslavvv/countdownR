using countdownR.API.DTOs.Account;
using FluentValidation;

namespace countdownR.API.Validators.Account;

public class RegisterAccountRequestValidator : AbstractValidator<RegisterAccountRequestDTO>
{
    public RegisterAccountRequestValidator()
    {
        RuleFor(x => x.Username)
           .NotEmpty()
           .WithMessage("Username Address cannot be empty!"); ;

        RuleFor(x => x.Email)
           .EmailAddress()
           .WithMessage("Email Address is not valid!")
           .NotEmpty()
           .WithMessage("Email Address cannot be empty!");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty!")
            .MinimumLength(12)
            .WithMessage("Password cannot be less than 12 characters!");
    }
}
