using Domain.Database.Repositories;
using FluentResults;
using SimpleCqrs;

namespace ApplicationLayer.Commands.UpdateActivityDay;

/// <summary>
/// Handles the <see cref="UpdateActivityDayCommand"/> by updating an existing activity day in the database.
/// </summary>
public class UpdateActivityDayCommandHandler(
    IActivityDayRepository activityDayRepository,
    IUnitOfWork unitOfWork)
    : IAsyncCommandHandler<UpdateActivityDayCommand, Result>
{
    /// <inheritdoc />
    public async Task<Result> HandleAsync(UpdateActivityDayCommand command, CancellationToken cancellationToken = default)
    {
        var activityDay = await activityDayRepository.GetByIdAsync(command.Id);

        if (activityDay is null)
        {
            return Result.Fail($"Activity day with id '{command.Id}' was not found.");
        }

        activityDayRepository.Update(activityDay, command.Date, command.LocalName, command.Name, command.CountryCode, command.Completed);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
