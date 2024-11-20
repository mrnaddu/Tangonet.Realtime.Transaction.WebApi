using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Tangonet.Realtime.Transaction.WebApi.Authentication;
using Tangonet.Realtime.Transaction.WebApi.Interfaces;
using Tangonet.Realtime.Transaction.WebApi.Services;

namespace Tangonet.Realtime.Transaction.WebApi;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication("ApiKey")
            .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKey", null);

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Real-Time API",
                Version = "v1",
                Description = "API for managing real-time "
            });
            const string securityDefinition = "ApiKey";
            c.AddSecurityDefinition(securityDefinition, new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "x-api-key",
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = securityDefinition
                    }
                },
                new List<string>()
            }
        });
        });

        services.AddControllers();

        // Aws Configuration
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
