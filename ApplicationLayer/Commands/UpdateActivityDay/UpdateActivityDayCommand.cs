using FluentResults;
using SimpleCqrs;

namespace ApplicationLayer.Commands.UpdateActivityDay;

/// <summary>
/// Represents a command to update an existing activity day in the database.
/// </summary>
public class UpdateActivityDayCommand : ICommand<Result>
{
    /// <summary>
    /// Gets or sets the identifier of the activity day to update.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the updated date of the activity day.
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Gets or sets the updated local name of the holiday.
    /// </summary>
    public string LocalName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated international name of the holiday.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated country code (e.g., "PL").
    /// </summary>
    public string CountryCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the activity day has been completed.
    /// </summary>
    public bool Completed { get; set; }
}
