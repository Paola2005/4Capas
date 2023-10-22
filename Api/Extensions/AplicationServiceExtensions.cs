using System.Text;
using Api.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
namespace API.Extension;

public static class ApplicationServiceExtensions
{
    public static void ConfigureCore(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy(
                "CorsPolicy",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
        });

    public static void AddApplicationServices(this IServiceCollection services)
    {
        /* services.AddScoped<IUnitOfWork, UnitOfWork>(); */
    }

    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JWT>(configuration.GetSection("JWT"));

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JWT:Key"])
                    )
                };
            });
    }
}
