using Microsoft.EntityFrameworkCore;
using Models.Database;

namespace Infrastructure.Database.DbQueries;

/// <summary>
/// Provides read-only query operations for activity day data.
/// </summary>
public class ActivityDayDbQuery : IActivityDayDbQuery
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of <see cref="ActivityDayDbQuery"/>.
    /// </summary>
    /// <param name="context">The database context.</param>
    public ActivityDayDbQuery(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<List<ActivityDayDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ActivityDays
            .AsNoTracking()
            .Select(a => new ActivityDayDto
            {
                Id = a.Id,
                Date = a.Date,
                LocalName = a.LocalName,
                Name = a.Name,
                CountryCode = a.CountryCode,
                Completed = a.Completed
            })
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<List<ActivityDayDto>> GetByCountryAsync(string countryCode, CancellationToken cancellationToken = default)
    {
        return await _context.ActivityDays
            .AsNoTracking()
            .Where(a => a.CountryCode == countryCode)
            .Select(a => new ActivityDayDto
            {
                Id = a.Id,
                Date = a.Date,
                LocalName = a.LocalName,
                Name = a.Name,
                CountryCode = a.CountryCode,
                Completed = a.Completed
            })
            .ToListAsync(cancellationToken);
    }
}
