using FastEndpoints;

namespace Anubis.Endpoints.RSA;

/// <summary>
///     Create RSA key
/// </summary>
public class CreateRsaKeyPair : Endpoint<CreateRsaKeyPairRequest>
{
    /// <inheritdoc />
    public override void Configure()
    {
        AllowAnonymous();
        Get("/rsa/create");
        Summary(
            s =>
            {
                s.Summary = "Create an RSA key pair";
                s.Description = s.Summary;
            }
        );
        Description(d => { d.WithTags(GetType().Namespace!.Split('.').Last()); });
    }

    /// <inheritdoc />
    public override async Task HandleAsync(CreateRsaKeyPairRequest req, CancellationToken ct)
    {
        var rsa = System.Security.Cryptography.RSA.Create(req.KeySize);
        var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
        var publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());

        await SendOkAsync(new { privateKey, publicKey }, ct);
    }
}