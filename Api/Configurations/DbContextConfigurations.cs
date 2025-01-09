using Microsoft.EntityFrameworkCore;
using CSharpDesignPatternsInPractice.Infra.Database;
using CSharpDesignPatternsInPractice.Infra.Database.Interface;
using CSharpDesignPatternsInPractice.Infra.Extensions;

namespace CSharpDesignPatternsInPractice.Api.Configurations;

public static class DbContextConfigurations
{
    public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.Validate("AppSettings:DB_CONN");

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString, optionsBuilder =>
            {
                optionsBuilder.MigrationsHistoryTable("__EFMigrationsHistory", ApplicationDbContext.Schema);
            }));

        return services;
    }
}
