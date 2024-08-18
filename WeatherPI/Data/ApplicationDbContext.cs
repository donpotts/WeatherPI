using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeatherPI.Models;
using WeatherPI.Shared.Models;

namespace WeatherPI.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<WeatherPIData> WeatherPIData => Set<WeatherPIData>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WeatherPIData>()
            .Property(e => e.Latitude)
            .HasConversion<double>();
        modelBuilder.Entity<WeatherPIData>()
            .Property(e => e.Latitude)
            .HasPrecision(19, 4);
        modelBuilder.Entity<WeatherPIData>()
            .Property(e => e.Longitude)
            .HasConversion<double>();
        modelBuilder.Entity<WeatherPIData>()
            .Property(e => e.Longitude)
            .HasPrecision(19, 4);
        modelBuilder.Entity<WeatherPIData>()
            .Property(e => e.Temperature)
            .HasConversion<double>();
        modelBuilder.Entity<WeatherPIData>()
            .Property(e => e.Temperature)
            .HasPrecision(19, 4);
        modelBuilder.Entity<WeatherPIData>()
            .Property(e => e.RelativeHumidity)
            .HasConversion<double>();
        modelBuilder.Entity<WeatherPIData>()
            .Property(e => e.RelativeHumidity)
            .HasPrecision(19, 4);
        modelBuilder.Entity<WeatherPIData>()
            .Property(e => e.BarometricPressure)
            .HasConversion<double>();
        modelBuilder.Entity<WeatherPIData>()
            .Property(e => e.BarometricPressure)
            .HasPrecision(19, 4);
    }
}
