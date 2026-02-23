using Microsoft.EntityFrameworkCore;
using Models.Database;

namespace Infrastructure.Database.DbQueries;

/// <summary>
/// Provides read-only query operations for activity day data.
/// </summary>
public class ActivityDayDbQuery(AppDbContext context) : IActivityDayDbQuery
{
    /// <summary>
    /// Returns all activity days projected to <see cref="ActivityDayDto"/>.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    public async Task<List<ActivityDayDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.ActivityDays
            .AsNoTracking()
            .Select(a => new ActivityDayDto
            {
                Id = a.Id,
                Date = a.Date,
                Name = a.Name,
                CountryCode = a.CountryCode,
                Completed = a.Completed
            })
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Returns all activity days for the specified country code projected to <see cref="ActivityDayDto"/>.
    /// </summary>
    /// <param name="countryCode">The ISO 3166-1 alpha-2 country code to filter by.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    public async Task<List<ActivityDayDto>> GetByCountryAsync(string countryCode, CancellationToken cancellationToken = default)
    {
        return await context.ActivityDays
            .AsNoTracking()
            .Where(a => a.CountryCode == countryCode)
            .Select(a => new ActivityDayDto
            {
                Id = a.Id,
                Date = a.Date,
                Name = a.Name,
                CountryCode = a.CountryCode,
                Completed = a.Completed
            })
            .ToListAsync(cancellationToken);
    }
}
