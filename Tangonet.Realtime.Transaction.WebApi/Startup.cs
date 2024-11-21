using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Tangonet.Realtime.Transaction.WebApi.Authentication;
using Tangonet.Realtime.Transaction.WebApi.Interfaces;
using Tangonet.Realtime.Transaction.WebApi.Middleware;
using Tangonet.Realtime.Transaction.WebApi.Services;

namespace Tangonet.Realtime.Transaction.WebApi;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication("ApiKey")
            .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKey", null);

        services.AddAuthorization(options =>
        {
            options.AddPolicy("ApiKeyPolicy", policy =>
                policy.RequireAuthenticatedUser());
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Real-Time API",
                Version = "v1",
                Description = "API for managing real-time "
            });

            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "x-api-key",
                Type = SecuritySchemeType.ApiKey,
                Description = "API Key needed to access the endpoints."
            });

            c.AddSecurityDefinition("PartnerId", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "x-partner-id",
                Type = SecuritySchemeType.ApiKey,
                Description = "Partner ID needed to access the endpoints."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "ApiKey"
                    }
                },
                Array.Empty<string>()
            },
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "PartnerId"
                    }
                },
                Array.Empty<string>()
            }
        });
        });

        services.AddControllers();

        // AWS Configuration
        services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

        // Dependency Injection
        services.AddScoped<ITransactionAppService, TransactionAppService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseMiddleware<CustomUnauthorizedResponseMiddleware>();

        app.UseAuthentication(); 

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Real-time API V1");
            c.RoutePrefix = string.Empty; 
        });
    }
}
