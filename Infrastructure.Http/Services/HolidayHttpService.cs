using System.Net.Http.Json;
using Domain.Http.Services;
using FluentResults;
using Models.Http;

namespace Infrastructure.Http.Services;

/// <summary>
/// Retrieves public holiday data from the Nager.Date API for a specific country.
/// </summary>
public class HolidayHttpService(HttpClient httpClient) : IHolidayHttpService
{
    /// <inheritdoc />
    public async Task<Result<List<HolidayModel>>> GetHolidaysAsync(string country, int year, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await httpClient.GetFromJsonAsync<List<HolidayModel>>(
                $"PublicHolidays/{year}/{country}",
                cancellationToken);

            return Result.Ok(result ?? []);
        }
        catch (HttpRequestException ex)
        {
            return Result.Fail<List<HolidayModel>>($"Failed to retrieve holidays: {ex.Message}");
        }
    }
}
