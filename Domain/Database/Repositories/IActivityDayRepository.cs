using Domain.Database.Entities;

namespace Domain.Database.Repositories;

/// <summary>
/// Defines the contract for the activity day repository.
/// </summary>
public interface IActivityDayRepository
{
    /// <summary>
    /// Adds a new activity day to the repository.
    /// </summary>
    /// <param name="activityDay">The activity day to add.</param>
    Task AddAsync(ActivityDay activityDay);

    /// <summary>
    /// Updates an existing activity day in the repository.
    /// </summary>
    /// <param name="activityDay">The activity day with updated values.</param>
    void Update(ActivityDay activityDay);

    /// <summary>
    /// Removes an activity day from the repository.
    /// </summary>
    /// <param name="activityDay">The activity day to remove.</param>
    void Remove(ActivityDay activityDay);

    /// <summary>
    /// Gets an activity day by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the activity day.</param>
    /// <returns>The activity day if found; otherwise, <c>null</c>.</returns>
    Task<ActivityDay?> GetByIdAsync(int id);

    /// <summary>
    /// Gets all activity days from the repository.
    /// </summary>
    /// <returns>A list of all activity days.</returns>
    Task<List<ActivityDay>> GetAllAsync();
}
