using Domain.Database.Entities;
using Domain.Database.Repositories;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Models.Database;

namespace Infrastructure.Database.Repositories;

/// <summary>
/// Implements data access operations for <see cref="ActivityDay"/> entities.
/// </summary>
public class ActivityDayRepository(AppDbContext context) : IActivityDayRepository
{
    /// <summary>
    /// Adds the given <paramref name="activityDay"/> to the database set without saving.
    /// </summary>
    /// <param name="activityDay">The activity day to add.</param>
    public async Task AddAsync(ActivityDay activityDay)
    {
        await context.ActivityDays.AddAsync(activityDay);
    }

    /// <summary>
    /// Finds the activity day by <paramref name="id"/>, applies the values from <paramref name="model"/>,
    /// and marks the entity as modified. Returns a failed result if the entity does not exist.
    /// </summary>
    /// <param name="id">The identifier of the activity day to update.</param>
    /// <param name="model">The model containing the new field values.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    public async Task<Result> UpdateAsync(int id, UpdateActivityDayModel model, CancellationToken cancellationToken = default)
    {
        var activityDay = await context.ActivityDays.FindAsync([id], cancellationToken);

        if (activityDay is null)
        {
            return Result.Fail($"Activity day with id '{id}' was not found.");
        }

        activityDay.Date = model.Date;
        activityDay.Name = model.Name;
        activityDay.CountryCode = model.CountryCode;
        activityDay.Completed = model.Completed;

        return Result.Ok();
    }

    /// <summary>
    /// Finds the activity day by <paramref name="id"/> and marks it for deletion.
    /// Returns a failed result if the entity does not exist.
    /// </summary>
    /// <param name="id">The identifier of the activity day to remove.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    public async Task<Result> RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        var activityDay = await context.ActivityDays.FindAsync([id], cancellationToken);

        if (activityDay is null)
        {
            return Result.Fail($"Activity day with id '{id}' was not found.");
        }

        context.ActivityDays.Remove(activityDay);

        return Result.Ok();
    }

    /// <summary>
    /// Returns the activity day with the given <paramref name="id"/>, or <c>null</c> if not found.
    /// </summary>
    /// <param name="id">The identifier of the activity day.</param>
    public async Task<ActivityDay?> GetByIdAsync(int id)
    {
        return await context.ActivityDays.FindAsync(id);
    }

    /// <summary>
    /// Returns all activity days in the database.
    /// </summary>
    public async Task<List<ActivityDay>> GetAllAsync()
    {
        return await context.ActivityDays.ToListAsync();
    }
}
