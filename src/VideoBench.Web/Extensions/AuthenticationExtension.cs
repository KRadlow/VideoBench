using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace VideoBench.Web.Extensions;

public static class AuthenticationExtension
{
    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {

        var authenticationBuilder = services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        });

        authenticationBuilder.AddJwtBearer(options =>
        {
            options.Authority = configuration["Authentication:Authority"];
            options.RequireHttpsMetadata = false;

            // Disable ASP.NET claims mapping
            options.MapInboundClaims = false;

            // JWT Token Validation
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidIssuer = configuration["Authentication:ValidIssuer"],
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true
            };

            // Event Authentication Handlers
            options.Events = new JwtBearerEvents()
            {
                OnTokenValidated = _ =>
                {
                    Console.WriteLine("User successfully authenticated");
                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = c =>
                {
                    c.NoResult();
                    c.Response.StatusCode = 500;
                    c.Response.ContentType = "text/plain";

                    return c.Response.WriteAsync("An error occured processing your authentication.");
                }
            };
        });
    }
}
