using FluentResults;
using Models.Http;
using SimpleCqrs;

namespace ApplicationLayer.Queries.GetHolidays;

/// <summary>
/// Represents a query to retrieve public holidays for a specific country and year.
/// </summary>
public class GetHolidaysQuery : IQuery<Result<List<HolidayModel>>>
{
    /// <summary>
    /// Gets or sets the ISO 3166-1 alpha-2 country code.
    /// </summary>
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the year for which to retrieve holidays.
    /// </summary>
    public int Year { get; set; }
}
