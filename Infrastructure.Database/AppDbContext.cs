using Domain.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

/// <summary>
/// The main Entity Framework Core database context for the application.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of <see cref="AppDbContext"/> with the specified options.
    /// </summary>
    /// <param name="options">The options to configure the context.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> of activity days.
    /// </summary>
    public DbSet<ActivityDay> ActivityDays { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
