using ApplicationLayer.Extensions;
using FluentResults;
using FluentValidation;
using Infrastructure.Database.DbQueries;
using Models.Database;
using SimpleCqrs;

namespace ApplicationLayer.Queries.GetActivityDays;

/// <summary>
/// Handles the <see cref="GetActivityDaysQuery"/> by fetching activity days from the database.
/// </summary>
public class GetActivityDaysQueryHandler(
    IActivityDayDbQuery activityDayDbQuery,
    IValidator<GetActivityDaysQuery> validator)
    : IAsyncQueryHandler<GetActivityDaysQuery, Result<List<ActivityDayDto>>>
{
    /// <inheritdoc />
    public async Task<Result<List<ActivityDayDto>>> HandleAsync(
        GetActivityDaysQuery query,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(query, cancellationToken);

        if (!validationResult.IsValid)
            return validationResult.ToResult<List<ActivityDayDto>>();

        var result = await activityDayDbQuery.GetByCountryAsync(query.CountryCode, cancellationToken);

        return Result.Ok(result);
    }
}
