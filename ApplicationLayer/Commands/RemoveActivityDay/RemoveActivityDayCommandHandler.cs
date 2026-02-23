using Domain.Database.Repositories;
using FluentResults;
using SimpleCqrs;

namespace ApplicationLayer.Commands.RemoveActivityDay;

/// <summary>
/// Handles the <see cref="RemoveActivityDayCommand"/> by removing an activity day from the database.
/// </summary>
public class RemoveActivityDayCommandHandler : IAsyncCommandHandler<RemoveActivityDayCommand, Result>
{
    private readonly IActivityDayRepository _activityDayRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of <see cref="RemoveActivityDayCommandHandler"/>.
    /// </summary>
    /// <param name="activityDayRepository">The activity day repository.</param>
    /// <param name="unitOfWork">The unit of work for persisting changes.</param>
    public RemoveActivityDayCommandHandler(
        IActivityDayRepository activityDayRepository,
        IUnitOfWork unitOfWork)
    {
        _activityDayRepository = activityDayRepository;
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc />
    public async Task<Result> HandleAsync(RemoveActivityDayCommand command, CancellationToken cancellationToken = default)
    {
        var activityDay = await _activityDayRepository.GetByIdAsync(command.Id);

        if (activityDay is null)
        {
            return Result.Fail($"Activity day with id '{command.Id}' was not found.");
        }

        _activityDayRepository.Remove(activityDay);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
