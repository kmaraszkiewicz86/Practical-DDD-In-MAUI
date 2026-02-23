using FluentResults;
using Infrastructure.Database.DbQueries;
using Models.Database;
using SimpleCqrs;

namespace ApplicationLayer.Queries.GetActivityDays;

/// <summary>
/// Handles the <see cref="GetActivityDaysQuery"/> by fetching activity days from the database.
/// </summary>
public class GetActivityDaysQueryHandler : IAsyncQueryHandler<GetActivityDaysQuery, Result<List<ActivityDayDto>>>
{
    private readonly IActivityDayDbQuery _activityDayDbQuery;

    /// <summary>
    /// Initializes a new instance of <see cref="GetActivityDaysQueryHandler"/>.
    /// </summary>
    /// <param name="activityDayDbQuery">The activity day database query service.</param>
    public GetActivityDaysQueryHandler(IActivityDayDbQuery activityDayDbQuery)
    {
        _activityDayDbQuery = activityDayDbQuery;
    }

    /// <inheritdoc />
    public async Task<Result<List<ActivityDayDto>>> HandleAsync(
        GetActivityDaysQuery query,
        CancellationToken cancellationToken = default)
    {
        List<ActivityDayDto> result;

        if (!string.IsNullOrWhiteSpace(query.CountryCode))
        {
            result = await _activityDayDbQuery.GetByCountryAsync(query.CountryCode, cancellationToken);
        }
        else
        {
            result = await _activityDayDbQuery.GetAllAsync(cancellationToken);
        }

        return Result.Ok(result);
    }
}
