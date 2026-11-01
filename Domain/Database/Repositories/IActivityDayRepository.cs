using Domain.Database.Entities;
using FluentResults;
using Models.Database;

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
    /// Updates an existing activity day identified by <paramref name="id"/> with the provided model values.
    /// Returns a failed result if the entity is not found.
    /// </summary>
    /// <param name="id">The identifier of the activity day to update.</param>
    /// <param name="model">The model containing the updated values.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    Task<Result> UpdateAsync(int id, UpdateActivityDayModel model, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes the activity day identified by <paramref name="id"/> from the repository.
    /// Returns a failed result if the entity is not found.
    /// </summary>
    /// <param name="id">The identifier of the activity day to remove.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    Task<Result> RemoveAsync(int id, CancellationToken cancellationToken = default);

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
