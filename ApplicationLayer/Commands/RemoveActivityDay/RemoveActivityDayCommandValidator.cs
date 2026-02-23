using FluentValidation;

namespace ApplicationLayer.Commands.RemoveActivityDay;

/// <summary>
/// Validates the <see cref="RemoveActivityDayCommand"/> before it is handled.
/// </summary>
public class RemoveActivityDayCommandValidator : AbstractValidator<RemoveActivityDayCommand>
{
    /// <summary>
    /// Initializes a new instance of <see cref="RemoveActivityDayCommandValidator"/> with validation rules.
    /// </summary>
    public RemoveActivityDayCommandValidator()
    {
        RuleFor(c => c.Id)
            .GreaterThan(0)
            .WithMessage("Id must be a positive number.");
    }
}
