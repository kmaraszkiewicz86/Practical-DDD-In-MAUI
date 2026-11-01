namespace Models.Database;

/// <summary>
/// Represents the data transfer object for an activity day read from the database.
/// </summary>
public class ActivityDayDto
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
