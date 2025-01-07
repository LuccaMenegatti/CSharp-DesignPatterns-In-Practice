using Microsoft.EntityFrameworkCore;
using AtividadeEmGrupoP2.Infra.Database;
using AtividadeEmGrupoP2.Infra.Database.Interface;
using AtividadeEmGrupoP2.Infra.Extensions;

namespace AtividadeEmGrupoP2.Api.Configurations;

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
