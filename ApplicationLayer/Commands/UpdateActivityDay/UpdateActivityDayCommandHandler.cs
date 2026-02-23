using ApplicationLayer.Extensions;
using Domain.Database.Repositories;
using FluentResults;
using FluentValidation;
using Models.Database;
using SimpleCqrs;

namespace ApplicationLayer.Commands.UpdateActivityDay;

/// <summary>
/// Handles the <see cref="UpdateActivityDayCommand"/> by updating an existing activity day in the database.
/// </summary>
public class UpdateActivityDayCommandHandler(
    IActivityDayRepository activityDayRepository,
    IUnitOfWork unitOfWork,
    IValidator<UpdateActivityDayCommand> validator)
    : IAsyncCommandHandler<UpdateActivityDayCommand, Result>
{
    /// <inheritdoc />
    public async Task<Result> HandleAsync(UpdateActivityDayCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            return validationResult.ToResult();

        var model = new UpdateActivityDayModel
        {
            Date = command.Date,
            Name = command.Name,
            CountryCode = command.CountryCode,
            Completed = command.Completed
        };

        var result = await activityDayRepository.UpdateAsync(command.Id, model, cancellationToken);

        if (result.IsFailed)
            return result;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
