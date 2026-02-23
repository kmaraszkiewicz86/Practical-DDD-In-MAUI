namespace Models.Database;

/// <summary>
/// Represents the model used to update an existing activity day.
/// </summary>
public class UpdateActivityDayModel
{
    /// <summary>
    /// Gets or sets the updated date of the activity day.
    /// </summary>
    public DateOnly Date { get; set; }

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
