using FluentResults;
using Models.Http;

namespace Domain.Http.Services;

/// <summary>
/// Defines the contract for retrieving public holiday data from the external HTTP API.
/// </summary>
public interface IHolidayHttpService
{
    /// <summary>
    /// Gets the public holidays for the specified country and year.
    /// Returns a failed result if the HTTP request cannot be completed.
    /// </summary>
    /// <param name="country">The ISO 3166-1 alpha-2 country code (e.g., "PL").</param>
    /// <param name="year">The year for which to retrieve holidays.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A result containing a list of holiday models, or a failure with error details.</returns>
    Task<Result<List<HolidayModel>>> GetHolidaysAsync(string country, int year, CancellationToken cancellationToken = default);
}
