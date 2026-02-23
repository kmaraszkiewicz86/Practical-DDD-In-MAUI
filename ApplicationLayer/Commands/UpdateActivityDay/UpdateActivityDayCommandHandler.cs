using Domain.Database.Repositories;
using FluentResults;
using SimpleCqrs;

namespace ApplicationLayer.Commands.UpdateActivityDay;

/// <summary>
/// Handles the <see cref="UpdateActivityDayCommand"/> by updating an existing activity day in the database.
/// </summary>
public class UpdateActivityDayCommandHandler : IAsyncCommandHandler<UpdateActivityDayCommand, Result>
{
    private readonly IActivityDayRepository _activityDayRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of <see cref="UpdateActivityDayCommandHandler"/>.
    /// </summary>
    /// <param name="activityDayRepository">The activity day repository.</param>
    /// <param name="unitOfWork">The unit of work for persisting changes.</param>
    public UpdateActivityDayCommandHandler(
        IActivityDayRepository activityDayRepository,
        IUnitOfWork unitOfWork)
    {
        _activityDayRepository = activityDayRepository;
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc />
    public async Task<Result> HandleAsync(UpdateActivityDayCommand command, CancellationToken cancellationToken = default)
    {
        var activityDay = await _activityDayRepository.GetByIdAsync(command.Id);

        if (activityDay is null)
        {
            return Result.Fail($"Activity day with id '{command.Id}' was not found.");
        }

        activityDay.Date = command.Date;
        activityDay.LocalName = command.LocalName;
        activityDay.Name = command.Name;
        activityDay.CountryCode = command.CountryCode;
        activityDay.Completed = command.Completed;

        _activityDayRepository.Update(activityDay);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
