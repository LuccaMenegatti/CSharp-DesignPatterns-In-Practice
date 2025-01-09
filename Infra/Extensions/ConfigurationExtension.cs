using System.Text.Json;

namespace CSharpDesignPatternsInPractice.Infra.Extensions;

public static class ConfigurationExtension
{
    public static string Validate(this IConfiguration configuration, string key)
    {
        return configuration[key] ?? throw new JsonException($"{key} not found");
    }

    public static T Validate<T>(this IConfiguration configuration, string key)
    {
        var value = configuration[key] ?? throw new JsonException($"{key} not found");
        return (T)Convert.ChangeType(value, typeof(T));
    }
}
