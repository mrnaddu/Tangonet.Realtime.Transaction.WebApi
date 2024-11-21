using System.Diagnostics;
using Newtonsoft.Json;

namespace Tangonet.Realtime.Transaction.WebApi.Middleware;

public class CustomUnauthorizedResponseMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                context.Response.StatusCode,
                Message = "Unauthorized access. Please provide valid API Key and Partner ID.",
                ErrorCode = "TNTTS4001",
                TraceId = context.TraceIdentifier
        }));
        }
    }
}
