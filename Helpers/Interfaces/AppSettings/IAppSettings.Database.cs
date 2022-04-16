namespace Anubis.Helpers.Interfaces.AppSettings;

/// <summary>
///     AppSettings for database related settings
/// </summary>
public partial interface IAppSettings
{
    /// <summary>
    ///     Default database connection string
    /// </summary>
    public string ConnectionString { get; }

    /// <summary>
    ///     Default database schema
    /// </summary>
    public string Schema { get; }
}