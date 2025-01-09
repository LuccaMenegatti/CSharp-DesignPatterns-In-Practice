using CSharpDesignPatternsInPractice.Api.Filters;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CSharpDesignPatternsInPractice.Api.Configurations;

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