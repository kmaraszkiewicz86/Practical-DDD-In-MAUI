using FluentResults;
using SimpleCqrs;

namespace ApplicationLayer.Commands.RemoveActivityDay;

/// <summary>
/// Represents a command to remove an activity day from the database.
/// </summary>
public class RemoveActivityDayCommand : ICommand<Result>
{
    /// <summary>
    /// Gets or sets the identifier of the activity day to remove.
    /// </summary>
    public int Id { get; set; }
}
