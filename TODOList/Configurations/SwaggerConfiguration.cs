using Microsoft.OpenApi.Models;

namespace TODOList.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwaggerOptions(WebApplicationBuilder builder)
    {
        var appVersion = Environment.GetEnvironmentVariable("APP_VERSION");
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc($"v{appVersion}", new OpenApiInfo
            {
                Version = $"v{appVersion}",
                Title = "ToDo API",
                Description = "An ASP.NET Core Web API for managing ToDo items",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            });
        });
    }

    public static void AddDevelopSwaggerOptions(WebApplicationBuilder builder, WebApplication app)
    {
        if (builder.Environment.IsDevelopment())
        {
            var appVersion = Environment.GetEnvironmentVariable("APP_VERSION");

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/v{appVersion}/swagger.json", $"v{appVersion}");
            });
        }
    }
}