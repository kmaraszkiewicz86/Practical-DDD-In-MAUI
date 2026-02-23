using System.Net.Http.Json;
using Domain.Http.Services;
using Models.Http;

namespace Infrastructure.Http.Services;

/// <summary>
/// Retrieves public holiday data from the Nager.Date API for a specific country.
/// </summary>
public class HolidayHttpService : IHolidayHttpService
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of <see cref="HolidayHttpService"/>.
    /// </summary>
    /// <param name="httpClient">The HTTP client configured for the Nager.Date API.</param>
    public HolidayHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc />
    public async Task<List<HolidayModel>> GetHolidaysAsync(string country, int year, CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetFromJsonAsync<List<HolidayModel>>(
            $"PublicHolidays/{year}/{country}",
            cancellationToken);

        return result ?? [];
    }
}
