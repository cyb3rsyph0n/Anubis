using System.Reflection;
using Serilog;

namespace Anubis.Helpers.Configurations;

/// <summary>
///     Configuration loader
/// </summary>
public static class Configuration
{
    /// <summary>
    ///     Load configuration from json files
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static IConfiguration LoadConfiguration()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
        var fileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);

        var configuration = new ConfigurationBuilder().SetBasePath(fileInfo.Directory?.FullName)
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.{environment}.json", false)
            .AddJsonFile("appsettings.Local.json", true)
            .AddEnvironmentVariables()
            .Build();

        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

        return configuration;
    }
}