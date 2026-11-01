using Models.Database;

namespace Infrastructure.Database.DbQueries;

/// <summary>
/// Defines the contract for querying activity day data from the database.
/// </summary>
public interface IActivityDayDbQuery
{
    /// <summary>
    /// Gets all activity days asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A list of activity day DTOs.</returns>
    Task<List<ActivityDayDto>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets activity days filtered by country code asynchronously.
    /// </summary>
    /// <param name="countryCode">The ISO 3166-1 alpha-2 country code to filter by.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A list of activity day DTOs matching the country code.</returns>
    Task<List<ActivityDayDto>> GetByCountryAsync(string countryCode, CancellationToken cancellationToken = default);
}
