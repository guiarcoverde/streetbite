using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StreetBite.Domain.Repositories;
using StreetBite.Domain.Repositories.Users.CommonUser;
using StreetBite.Infrastructure.DataAccess;
using StreetBite.Infrastructure.DataAccess.Repositories;
using StreetBite.Infrastructure.Identity;

namespace StreetBite.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddSecurity(services);
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
}