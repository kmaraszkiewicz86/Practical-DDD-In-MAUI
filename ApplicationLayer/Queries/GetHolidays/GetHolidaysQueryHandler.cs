using Domain.Http.Services;
using FluentResults;
using FluentValidation;
using Models.Http;
using SimpleCqrs;

namespace ApplicationLayer.Queries.GetHolidays;

/// <summary>
/// Handles the <see cref="GetHolidaysQuery"/> by fetching holiday data from the external API.
/// </summary>
public class GetHolidaysQueryHandler : IAsyncQueryHandler<GetHolidaysQuery, Result<List<HolidayModel>>>
{
    private readonly IHolidayHttpService _holidayHttpService;
    private readonly IValidator<GetHolidaysQuery> _validator;

    /// <summary>
    /// Initializes a new instance of <see cref="GetHolidaysQueryHandler"/>.
    /// </summary>
    /// <param name="holidayHttpService">The holiday HTTP service.</param>
    /// <param name="validator">The query validator.</param>
    public GetHolidaysQueryHandler(
        IHolidayHttpService holidayHttpService,
        IValidator<GetHolidaysQuery> validator)
    {
        _holidayHttpService = holidayHttpService;
        _validator = validator;
    }

    /// <inheritdoc />
    public async Task<Result<List<HolidayModel>>> HandleAsync(
        GetHolidaysQuery query,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(query, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => new Error(e.ErrorMessage))
                .ToList();

            return Result.Fail<List<HolidayModel>>(errors);
        }

        var holidays = await _holidayHttpService.GetHolidaysAsync(query.Country, query.Year, cancellationToken);

        return Result.Ok(holidays);
    }
}
