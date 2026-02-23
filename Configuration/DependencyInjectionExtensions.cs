using ApplicationLayer.Queries.GetHolidays;
using Domain.Database.Repositories;
using Domain.Http.Services;
using FluentValidation;
using Infrastructure.Database;
using Infrastructure.Database.DbQueries;
using Infrastructure.Database.Repositories;
using Infrastructure.Http.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleCqrs;

namespace Configuration;

/// <summary>
/// Provides extension methods for configuring the application's dependency injection container.
/// </summary>
public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Registers Entity Framework Core with a SQLite database at the given connection string.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="connectionString">The SQLite connection string.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<IActivityDayRepository, ActivityDayRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IActivityDayDbQuery, ActivityDayDbQuery>();

        return services;
    }

    /// <summary>
    /// Registers the Nager.Date HTTP client and the holiday HTTP service.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddHolidayHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient<IHolidayHttpService, HolidayHttpService>(client =>
        {
            client.BaseAddress = new Uri("https://date.nager.at/api/v3/");
        });

        return services;
    }

    /// <summary>
    /// Registers the CQRS handlers from the ApplicationLayer assembly,
    /// along with FluentValidation validators.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.ConfigureSimpleCqrs(
            typeof(GetHolidaysQueryHandler).Assembly,
            SimpleCqrs.ServiceCollectionExtensions.HandlerLifetime.Scoped);

        services.AddValidatorsFromAssembly(typeof(GetHolidaysQueryValidator).Assembly);

        return services;
    }
}
