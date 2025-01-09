using CSharpDesignPatternsInPractice.Domain.UseCases.FootballPlayers;
using CSharpDesignPatternsInPractice.Domain.UseCases.FootballTeams;
using CSharpDesignPatternsInPractice.Infra.Repositories;
using CSharpDesignPatternsInPractice.Infra.Repositories.Interfaces;
using CSharpDesignPatternsInPractice.Infra.Repositories;

namespace CSharpDesignPatternsInPractice.Api.Configurations;

public static class DependencyInjectionConfigurations
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddUseCases();
        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreatePlayerUseCase, CreatePlayerUseCase>();
        services.AddScoped<IUpdatePlayerUseCase, UpdatePlayerUseCase>();
        services.AddScoped<IDeletePlayerUseCase, DeletePlayerUseCase>();
        services.AddScoped<IGetPlayersUseCase, GetPlayersUseCase>();
        services.AddScoped<IGetPlayerByIdUseCase, GetPlayerByIdUseCase>();

        services.AddScoped<ICreateTeamUseCase, CreateTeamUseCase>();
        services.AddScoped<IUpdateTeamUseCase, UpdateTeamUseCase>();
        services.AddScoped<IDeleteTeamUseCase, DeleteTeamUseCase>();
        services.AddScoped<IGetTeamsUseCase, GetTeamsUseCase>();
        services.AddScoped<IGetTeamByIdUseCase, GetTeamByIdUseCase>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IFootballPlayerRepository, FootballPlayerRepository>();
        services.AddScoped<IFootballTeamRepository, FootballTeamRepository>();

        return services;
    }
}
