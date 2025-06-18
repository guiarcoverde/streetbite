using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StreetBite.Domain.Repositories;
using StreetBite.Domain.Repositories.Users.CommonUser;
using StreetBite.Domain.Security.Tokens;
using StreetBite.Domain.Services.Login.CommonUser;
using StreetBite.Infrastructure.DataAccess;
using StreetBite.Infrastructure.DataAccess.Repositories;
using StreetBite.Infrastructure.Identity;
using StreetBite.Infrastructure.Security.Token;

namespace StreetBite.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddSecurity(services);
        AddToken(services, configuration);
        AddDbContext(services, configuration);
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICommonUserWriteOnlyRepository, CommonUserRepository>();
    }
    
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        string psqlConnectionString = configuration.GetConnectionString("PSqlConnectionString")!;

        services.AddDbContext<StreetBiteDbContext>(config =>
            config.UseNpgsql(psqlConnectionString));
    }
    
    private static void AddSecurity(IServiceCollection services)
    {
        services.AddTransient<RoleSeeder>();
        services.AddScoped<ICommonUserLoginService, LoginService>();
        
        services
            .AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false; 
                options.Password.RequiredUniqueChars = 0;
            })
            .AddEntityFrameworkStores<StreetBiteDbContext>()
            .AddDefaultTokenProviders();
    }

    private static void AddToken(this IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");
        services.AddScoped<IAccessTokenGenerator>(opt => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
    }
}