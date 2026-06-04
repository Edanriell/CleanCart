using Microsoft.Extensions.Configuration;

namespace Infrastructure.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddCoreLayerConfiguration(this IConfigurationBuilder configurationBuilder)
    {
        const string envVariable = "ASPNETCORE_ENVIRONMENT";
        var environment = Environment.GetEnvironmentVariable(envVariable) ??
                          throw new ArgumentNullException(envVariable);

        configurationBuilder.AddJsonFile("appsettings.core.json", false);
        configurationBuilder.AddJsonFile($"appsettings.core.{environment}.json", false);

        if (environment.Equals("Development", StringComparison.OrdinalIgnoreCase))
            configurationBuilder.AddUserSecrets(typeof(ConfigurationBuilderExtensions).Assembly, true);

        configurationBuilder.AddEnvironmentVariables();

        return configurationBuilder;
    }
}