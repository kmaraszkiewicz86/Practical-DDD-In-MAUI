using Domain.Database.Entities;
using FluentResults;
using SimpleCqrs;

namespace ApplicationLayer.Commands.AddActivityDay;

/// <summary>
/// Represents a command to add a new activity day to the database.
/// </summary>
public class AddActivityDayCommand : ICommand<Result>
{
    /// <summary>
    /// Gets or sets the date of the activity day.
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Gets or sets the local name of the holiday.
    /// </summary>
    public string LocalName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the international name of the holiday.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the country code (e.g., "PL").
    /// </summary>
    public string CountryCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the activity day has been completed.
    /// </summary>
    public bool Completed { get; set; }
}
