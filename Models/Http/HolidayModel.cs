using System.Text.Json.Serialization;

namespace Models.Http;

/// <summary>
/// Represents a public holiday returned by the Nager.Date API.
/// </summary>
public class HolidayModel
{
    /// <summary>
    /// Gets or sets the date of the holiday.
    /// </summary>
    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the local name of the holiday.
    /// </summary>
    [JsonPropertyName("localName")]
    public string LocalName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the international name of the holiday.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ISO 3166-1 alpha-2 country code.
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the holiday is a fixed date each year.
    /// </summary>
    [JsonPropertyName("fixed")]
    public bool Fixed { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the holiday applies globally within the country.
    /// </summary>
    [JsonPropertyName("global")]
    public bool Global { get; set; }

    /// <summary>
    /// Gets or sets the types of the holiday (e.g., "Public").
    /// </summary>
    [JsonPropertyName("types")]
    public List<string> Types { get; set; } = [];
}
