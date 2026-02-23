using ApplicationLayer.Extensions;
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
            return validationResult.ToResult();

        var result = await activityDayRepository.RemoveAsync(command.Id, cancellationToken);

        if (result.IsFailed)
            return result;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
