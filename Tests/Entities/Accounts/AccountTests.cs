using System.Diagnostics.CodeAnalysis;
using Anubis.Entities.Accounts;
using Anubis.Helpers.Extensions;
using Anubis.Helpers.Interfaces.AppSettings;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Anubis.Tests.Entities.Accounts;

[ExcludeFromCodeCoverage]
public class AccountTests
{
    [Fact]
    public void VerifyAccountPopulatesFields()
    {
        var appSettings = Substitute.For<IAppSettings>();
        appSettings.KnownSalt.Returns("salt");
        appSettings.Iterations.Returns(1000);
        appSettings.SaltLength.Returns(32);
        appSettings.HashSize.Returns(32);

        var setup = new Account("foo@bar.com", appSettings);

        setup.Should().NotBeNull();
        setup.Id.Should().BeEmpty();
        setup.EmailAddress.Should().Be("foo@bar.com");
        setup.ApiKey.Should().NotBeEmpty();
        setup.Secret.Should().NotBeEmpty();

        setup.ApiKey.VerifySaltedHash(
                "foo@bar.com",
                appSettings.KnownSalt,
                appSettings.SaltLength,
                appSettings.Iterations,
                appSettings.HashSize
            )
            .Should()
            .BeTrue();
        setup.Secret.VerifySaltedHash(setup.ApiKey, appSettings.KnownSalt, 8, appSettings.Iterations, 4)
            .Should()
            .BeTrue();
    }
}