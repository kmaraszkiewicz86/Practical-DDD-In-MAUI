using Domain.Database.Entities;
using Domain.Database.Repositories;
using FluentResults;
using FluentValidation;
using SimpleCqrs;

namespace ApplicationLayer.Commands.AddActivityDay;

/// <summary>
/// Handles the <see cref="AddActivityDayCommand"/> by persisting a new activity day to the database.
/// </summary>
public class AddActivityDayCommandHandler(
    IActivityDayRepository activityDayRepository,
    IUnitOfWork unitOfWork,
    IValidator<AddActivityDayCommand> validator)
    : IAsyncCommandHandler<AddActivityDayCommand, Result>
{
    /// <inheritdoc />
    public async Task<Result> HandleAsync(AddActivityDayCommand command, CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => new Error(e.ErrorMessage))
                .ToList();

            return Result.Fail(errors);
        }

        var activityDay = new ActivityDay
        {
            Date = command.Date,
            LocalName = command.LocalName,
            Name = command.Name,
            CountryCode = command.CountryCode,
            Completed = command.Completed
        };

        await activityDayRepository.AddAsync(activityDay);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
