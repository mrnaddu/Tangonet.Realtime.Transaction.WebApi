using System.Configuration;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Tangonet.Realtime.Transaction.WebApi.Authentication;

[method: Obsolete]
public class ApiKeyAuthenticationHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder,
    ISystemClock clock) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder, clock)
{
    private static readonly HashSet<string> ValidApiKeys =
    [
        Environment.GetEnvironmentVariable("ApiKey")
    ];

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue("x-api-key", out var apiKey))
        {
            return Task.FromResult(AuthenticateResult.Fail("API Key not provided"));
        }

        if (!ValidApiKeys.Contains(apiKey))
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid API Key"));
        }

        var claims = new[] { new Claim(ClaimTypes.Name, "ApiUser ") };
        var identity = new ClaimsIdentity(claims, "ApiKey");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "ApiKey");

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
