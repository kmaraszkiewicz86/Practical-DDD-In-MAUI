using FluentResults;
using Models.Database;
using SimpleCqrs;

namespace ApplicationLayer.Queries.GetActivityDays;

/// <summary>
/// Represents a query to retrieve activity days from the database.
/// </summary>
public class GetActivityDaysQuery : IQuery<Result<List<ActivityDayDto>>>
{
    /// <summary>
    /// Gets or sets an optional country code filter.
    /// When set, only activity days with the matching country code are returned.
    /// </summary>
    public string? CountryCode { get; set; }
}
