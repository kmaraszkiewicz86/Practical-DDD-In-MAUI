using Domain.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

/// <summary>
/// Configures the <see cref="ActivityDay"/> entity mapping for Entity Framework Core.
/// </summary>
public class ActivityDayConfiguration : IEntityTypeConfiguration<ActivityDay>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<ActivityDay> builder)
    {
        builder.ToTable("ActivityDays");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Date)
            .IsRequired();

        builder.Property(a => a.LocalName)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(a => a.CountryCode)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(a => a.Completed)
            .IsRequired()
            .HasDefaultValue(false);
    }
}
