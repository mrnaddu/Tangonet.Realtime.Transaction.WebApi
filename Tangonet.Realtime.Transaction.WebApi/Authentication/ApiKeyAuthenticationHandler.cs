using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Tangonet.Realtime.Transaction.WebApi.Authentication;

[method: Obsolete]
public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private static readonly Dictionary<string, string> ValidApiKeys = new()
    {
        { 
            Environment.GetEnvironmentVariable("ApiKey"),
            Environment.GetEnvironmentVariable("PartnerId") 
        }
    };

    [Obsolete]
    public ApiKeyAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock) : base(options, logger, encoder, clock) { }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue("x-api-key", out var apiKey))
        {
            return Task.FromResult(AuthenticateResult.Fail("API Key not provided"));
        }

        if (!Request.Headers.TryGetValue("x-partner-id", out var partnerId))
        {
            return Task.FromResult(AuthenticateResult.Fail("Partner ID not provided"));
        }

        if (!ValidApiKeys.TryGetValue(apiKey, out var expectedPartnerId) || expectedPartnerId != partnerId)
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid API Key or Partner ID"));
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "ApiUser "),
            new Claim("PartnerId", partnerId) 
        };

        var identity = new ClaimsIdentity(claims, "ApiKey");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "ApiKey");

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
