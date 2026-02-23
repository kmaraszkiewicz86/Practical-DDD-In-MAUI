using Domain.Database.Entities;
using Domain.Database.Repositories;
using FluentResults;
using SimpleCqrs;

namespace ApplicationLayer.Commands.AddActivityDay;

/// <summary>
/// Handles the <see cref="AddActivityDayCommand"/> by persisting a new activity day to the database.
/// </summary>
public class AddActivityDayCommandHandler : IAsyncCommandHandler<AddActivityDayCommand, Result>
{
    private readonly IActivityDayRepository _activityDayRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of <see cref="AddActivityDayCommandHandler"/>.
    /// </summary>
    /// <param name="activityDayRepository">The activity day repository.</param>
    /// <param name="unitOfWork">The unit of work for persisting changes.</param>
    public AddActivityDayCommandHandler(
        IActivityDayRepository activityDayRepository,
        IUnitOfWork unitOfWork)
    {
        _activityDayRepository = activityDayRepository;
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc />
    public async Task<Result> HandleAsync(AddActivityDayCommand command, CancellationToken cancellationToken = default)
    {
        var activityDay = new ActivityDay
        {
            Date = command.Date,
            LocalName = command.LocalName,
            Name = command.Name,
            CountryCode = command.CountryCode,
            Completed = command.Completed
        };

        await _activityDayRepository.AddAsync(activityDay);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
