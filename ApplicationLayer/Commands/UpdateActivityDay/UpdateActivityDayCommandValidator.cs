using Domain.Database.Repositories;
using FluentValidation;

namespace ApplicationLayer.Commands.UpdateActivityDay;

/// <summary>
/// Validates the <see cref="UpdateActivityDayCommand"/> before it is handled.
/// </summary>
public class UpdateActivityDayCommandValidator : AbstractValidator<UpdateActivityDayCommand>
{
    /// <summary>
    /// Initializes a new instance of <see cref="UpdateActivityDayCommandValidator"/> with validation rules.
    /// </summary>
    public UpdateActivityDayCommandValidator()
    {
        RuleFor(c => c.Id)
            .GreaterThan(0)
            .WithMessage("Id must be a positive number.");

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
