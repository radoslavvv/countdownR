using countdownR.API.DTOs.Countdown;
using FluentValidation;

namespace countdownR.API.Validators.Countdown;

public class UpdateCountdownRequestValidator : AbstractValidator<UpdateCountdownRequestDTO>
{
    public UpdateCountdownRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(50);

        RuleFor(x => x.Date)
            .NotEmpty();

        RuleFor(x => x.Subtitle)
            .MinimumLength(1)
            .MaximumLength(50);

        RuleFor(x => x.DigitsColor)
            .MinimumLength(1);

        RuleFor(x => x.TilesColor)
            .MinimumLength(1);

        RuleFor(x => x.BackgroundImageUrl)
            .MinimumLength(1);
    }
}
