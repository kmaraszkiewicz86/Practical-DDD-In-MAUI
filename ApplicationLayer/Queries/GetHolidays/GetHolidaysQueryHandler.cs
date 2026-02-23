using Domain.Http.Services;
using FluentResults;
using FluentValidation;
using Infrastructure.Database.DbQueries;
using Models.Http;
using SimpleCqrs;

namespace ApplicationLayer.Queries.GetHolidays;

/// <summary>
/// Handles the <see cref="GetHolidaysQuery"/> by fetching holiday data from the external API
/// and merging it with saved activity days from the database for the requested country.
/// </summary>
public class GetHolidaysQueryHandler(
    IHolidayHttpService holidayHttpService,
    IActivityDayDbQuery activityDayDbQuery,
    IValidator<GetHolidaysQuery> validator)
    : IAsyncQueryHandler<GetHolidaysQuery, Result<List<HolidayModel>>>
{
    /// <inheritdoc />
    public async Task<Result<List<HolidayModel>>> HandleAsync(
        GetHolidaysQuery query,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(query, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => new Error(e.ErrorMessage))
                .ToList();

            return Result.Fail<List<HolidayModel>>(errors);
        }

        var holidays = await holidayHttpService.GetHolidaysAsync(query.Country, query.Year, cancellationToken);

        var dbActivityDays = await activityDayDbQuery.GetByCountryAsync(query.Country, cancellationToken);

        var dbHolidays = dbActivityDays
            .Where(a => a.Date.Year == query.Year)
            .Select(a => new HolidayModel
        {
            Date = a.Date.ToString("yyyy-MM-dd"),
            LocalName = a.LocalName,
            Name = a.Name,
            CountryCode = a.CountryCode
        });

        var merged = holidays
            .Concat(dbHolidays)
            .DistinctBy(h => h.Date)
            .ToList();

        return Result.Ok(merged);
    }
}
