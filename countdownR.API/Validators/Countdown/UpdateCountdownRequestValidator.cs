using countdownR.API.DTOs.Countdown;
using FluentValidation;

namespace countdownR.API.Validators.Countdown;

public class UpdateCountdownRequestValidator : AbstractValidator<UpdateCountdownRequestDTO>
{
    public UpdateCountdownRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title cannot be empty!")
            .MinimumLength(1)
            .WithMessage("Title cannot be less than 1 character!")
            .MaximumLength(50)
            .WithMessage("Title cannot be more than 50 characters!");

        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("Date cannot be empty!");

        RuleFor(x => x.Subtitle)
            .MinimumLength(1)
            .WithMessage("Subtitle cannot be less than 1 character!")
            .MaximumLength(50)
            .WithMessage("Subtitle cannot be more than 50 characters!");

        RuleFor(x => x.DigitsColor)
            .MinimumLength(1)
            .WithMessage("Digits Color cannot be less than 1 character!");

        RuleFor(x => x.TilesColor)
            .MinimumLength(1)
            .WithMessage("Tiles Color cannot be less than 1 character!");

        RuleFor(x => x.BackgroundImageUrl)
            .MinimumLength(1)
            .WithMessage("BackgroundImageUrl cannot be less than 1 character!");
    }
}
