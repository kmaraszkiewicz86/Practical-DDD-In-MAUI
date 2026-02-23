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
    /// Gets or sets the country code to filter activity days by.
    /// </summary>
    public string CountryCode { get; set; } = string.Empty;
}
