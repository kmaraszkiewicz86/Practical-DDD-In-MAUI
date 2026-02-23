using FluentValidation;

namespace ApplicationLayer.Commands.AddActivityDay;

/// <summary>
/// Validates the <see cref="AddActivityDayCommand"/> before it is handled.
/// </summary>
public class AddActivityDayCommandValidator : AbstractValidator<AddActivityDayCommand>
{
    /// <summary>
    /// Initializes a new instance of <see cref="AddActivityDayCommandValidator"/> with validation rules.
    /// </summary>
    public AddActivityDayCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name must not be empty.");

        RuleFor(c => c.CountryCode)
            .NotEmpty()
            .WithMessage("Country code must not be empty.")
            .Length(2, 2)
            .WithMessage("Country code must be exactly 2 characters.");
    }
}
