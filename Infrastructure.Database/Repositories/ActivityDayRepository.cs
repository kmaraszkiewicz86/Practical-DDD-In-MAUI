using Domain.Database.Entities;
using Domain.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

/// <summary>
/// Implements data access operations for <see cref="ActivityDay"/> entities.
/// </summary>
public class ActivityDayRepository : IActivityDayRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of <see cref="ActivityDayRepository"/>.
    /// </summary>
    /// <param name="context">The database context.</param>
    public ActivityDayRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task AddAsync(ActivityDay activityDay)
    {
        await _context.ActivityDays.AddAsync(activityDay);
    }

    /// <inheritdoc />
    public void Update(ActivityDay activityDay)
    {
        _context.ActivityDays.Update(activityDay);
    }

    /// <inheritdoc />
    public void Remove(ActivityDay activityDay)
    {
        _context.ActivityDays.Remove(activityDay);
    }

    /// <inheritdoc />
    public async Task<ActivityDay?> GetByIdAsync(int id)
    {
        return await _context.ActivityDays.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task<List<ActivityDay>> GetAllAsync()
    {
        return await _context.ActivityDays.ToListAsync();
    }
}
