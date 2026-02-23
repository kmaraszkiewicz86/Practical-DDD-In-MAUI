using FluentResults;
using FluentValidation.Results;

namespace ApplicationLayer.Extensions;

/// <summary>
/// Provides extension methods for converting <see cref="ValidationResult"/> instances to FluentResults types.
/// </summary>
public static class ValidationResultExtensions
{
    /// <summary>
    /// Converts a failed <see cref="ValidationResult"/> to a <see cref="Result"/>.
    /// </summary>
    /// <param name="validationResult">The validation result containing errors.</param>
    public static Result ToResult(this ValidationResult validationResult)
        => Result.Fail(MapErrors(validationResult));

    /// <summary>
    /// Converts a failed <see cref="ValidationResult"/> to a <see cref="Result{T}"/>.
    /// </summary>
    /// <typeparam name="T">The value type of the result.</typeparam>
    /// <param name="validationResult">The validation result containing errors.</param>
    public static Result<T> ToResult<T>(this ValidationResult validationResult)
        => Result.Fail<T>(MapErrors(validationResult));

    private static List<Error> MapErrors(ValidationResult validationResult)
        => validationResult.Errors
            .Select(e => new Error(e.ErrorMessage))
            .ToList();
}
