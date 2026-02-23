namespace Domain.Database.Entities;

/// <summary>
/// Represents an activity day entity stored in the database.
/// </summary>
public class ActivityDay
{
    /// <summary>
    /// Gets or sets the unique identifier.
    /// </summary>
    public int Id { get; set; }

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
