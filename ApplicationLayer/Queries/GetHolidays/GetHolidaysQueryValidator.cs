using FluentValidation;

namespace ApplicationLayer.Queries.GetHolidays;

/// <summary>
/// Validates the <see cref="GetHolidaysQuery"/> before it is handled.
/// </summary>
public class GetHolidaysQueryValidator : AbstractValidator<GetHolidaysQuery>
{
    /// <summary>
    /// Initializes a new instance of <see cref="GetHolidaysQueryValidator"/> with validation rules.
    /// </summary>
    public GetHolidaysQueryValidator()
    {
        RuleFor(q => q.Country)
            .NotEmpty()
            .WithMessage("Country code must not be empty.")
            .Length(2, 2)
            .WithMessage("Country code must be exactly 2 characters.");
    }
}
