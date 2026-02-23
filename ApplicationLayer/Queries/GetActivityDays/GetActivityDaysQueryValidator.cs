using FluentValidation;

namespace ApplicationLayer.Queries.GetActivityDays;

/// <summary>
/// Validates the <see cref="GetActivityDaysQuery"/> before it is handled.
/// </summary>
public class GetActivityDaysQueryValidator : AbstractValidator<GetActivityDaysQuery>
{
    /// <summary>
    /// Initializes a new instance of <see cref="GetActivityDaysQueryValidator"/> with validation rules.
    /// </summary>
    public GetActivityDaysQueryValidator()
    {
        RuleFor(q => q.CountryCode)
            .NotEmpty()
            .WithMessage("Country code must not be empty.")
            .Length(2, 2)
            .WithMessage("Country code must be exactly 2 characters.");
    }
}
