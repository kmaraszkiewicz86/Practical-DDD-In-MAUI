using Domain.Database.Repositories;
using FluentResults;
using FluentValidation;
using SimpleCqrs;

namespace ApplicationLayer.Commands.RemoveActivityDay;

/// <summary>
/// Handles the <see cref="RemoveActivityDayCommand"/> by removing an activity day from the database.
/// </summary>
public class RemoveActivityDayCommandHandler(
    IActivityDayRepository activityDayRepository,
    IUnitOfWork unitOfWork,
    IValidator<RemoveActivityDayCommand> validator)
    : IAsyncCommandHandler<RemoveActivityDayCommand, Result>
{
    /// <inheritdoc />
    public async Task<Result> HandleAsync(RemoveActivityDayCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => new Error(e.ErrorMessage))
                .ToList();

            return Result.Fail(errors);
        }

        var activityDay = await activityDayRepository.GetByIdAsync(command.Id);

        if (activityDay is null)
        {
            return Result.Fail($"Activity day with id '{command.Id}' was not found.");
        }

        activityDayRepository.Remove(activityDay);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
