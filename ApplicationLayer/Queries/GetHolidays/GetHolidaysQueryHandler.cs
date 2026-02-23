using ApplicationLayer.Extensions;
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
/// The current year is used automatically.
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
            return validationResult.ToResult<List<HolidayModel>>();

        var year = DateTime.UtcNow.Year;

        var holidaysResult = await holidayHttpService.GetHolidaysAsync(query.Country, year, cancellationToken);

        if (holidaysResult.IsFailed)
            return holidaysResult;

        var dbActivityDays = await activityDayDbQuery.GetByCountryAsync(query.Country, cancellationToken);

        var dbHolidays = dbActivityDays
            .Where(a => a.Date.Year == year)
            .Select(a => new HolidayModel
            {
                Date = a.Date.ToString("yyyy-MM-dd"),
                Name = a.Name,
                CountryCode = a.CountryCode
            });

        var merged = holidaysResult.Value
            .Concat(dbHolidays)
            .DistinctBy(h => h.Date)
            .ToList();

        return Result.Ok(merged);
    }
}
