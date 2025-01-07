using AtividadeEmGrupoP2.Api.Filters;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace AtividadeEmGrupoP2.Api.Configurations;

public static class ApiConfiguration
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
    {
        services
            .AddControllers(options => options.Filters.Add(new ModelValidationActionFilter()))
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

        services.AddFluentValidationAutoValidation(c =>
        {
            c.DisableDataAnnotationsValidation = true;
        });
        services.AddValidatorsFromAssemblyContaining<Program>();

        return services;
    }
}