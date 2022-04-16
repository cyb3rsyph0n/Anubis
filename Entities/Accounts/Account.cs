using Anubis.Entities.Base.Types;
using Anubis.Helpers.Extensions;
using Anubis.Helpers.Interfaces.AppSettings;

namespace Anubis.Entities.Accounts;

public class Account : BaseEntity
{
    private readonly string apiKey = null!;
    private readonly string emailAddress = null!;
    private readonly string secret = null!;

    /// <summary>
    ///     Required for EF
    /// </summary>
    [Obsolete("For EF only")]
    public Account()
    {
    }

    /// <summary>
    ///     Default ctor
    /// </summary>
    /// <param name="emailAddress">Required email address</param>
    /// <param name="appSettings">Required app settings for security settings</param>
    public Account(string emailAddress, IAppSettings appSettings)
    {
        this.emailAddress = emailAddress;
        apiKey = emailAddress.GenerateSaltedHash(
            appSettings.KnownSalt,
            appSettings.SaltLength,
            appSettings.Iterations,
            appSettings.HashSize
        );
        secret = apiKey.GenerateSaltedHash(appSettings.KnownSalt, 8, appSettings.Iterations, 4);
    }

    /// <summary>
    ///     Account api key
    /// </summary>
    public string ApiKey => apiKey;

    /// <summary>
    ///     Account email address
    /// </summary>
    public string EmailAddress => emailAddress;

    /// <summary>
    ///     Account api secret
    /// </summary>
    public string Secret => secret;
}