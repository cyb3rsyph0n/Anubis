// ReSharper disable UnusedAutoPropertyAccessor.Global

using FastEndpoints;

namespace Anubis.Endpoints.RSA;

/// <summary>
///     Request params
/// </summary>
public class CreateRsaKeyPairRequest
{
    [QueryParam]
    public int KeySize { get; set; }
}