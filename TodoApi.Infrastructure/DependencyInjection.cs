using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TodoApi.Application.Common.Interfaces.Authentication;
using TodoApi.Application.Common.Interfaces.Services;
using TodoApi.Domain.Repositories;
using TodoApi.Infrastructure.Common.Authentication;
using TodoApi.Infrastructure.Common.Services;
using TodoApi.Infrastructure.Data;
using TodoApi.Infrastructure.Persistence;

namespace TodoApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString(ApplicationDbContextSettings.ConnectionStrings));
        });
        services.Configure<JwtTokenSettings>(configuration.GetSection(JwtTokenSettings.SectionName));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetSection("JwtSettings:Issuer").Value,
                    ValidAudience = configuration.GetSection("JwtSettings:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings:Secret").Value))
                };
            });

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHashGenerator, PasswordHashGenerator>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITodoRepository, TodoRepository>();

        return services;
    }
}