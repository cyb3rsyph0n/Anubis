namespace Anubis.Helpers.Interfaces.AppSettings;

/// <summary>
///     App settings for security related settings
/// </summary>
public partial interface IAppSettings
{
    /// <summary>
    ///     Hash size to return
    /// </summary>
    int HashSize { get; }

    /// <summary>
    ///     Number of hashing iterations
    /// </summary>
    int Iterations { get; }

    /// <summary>
    ///     Known salt value
    /// </summary>
    string KnownSalt { get; }

    /// <summary>
    ///     Random salt length
    /// </summary>
    int SaltLength { get; }
}