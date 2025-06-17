using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StreetBite.Domain.Repositories;
using StreetBite.Domain.Repositories.User;
using StreetBite.Infrastructure.DataAccess;

namespace StreetBite.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext(services, configuration);
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserWriteOnlyRepository>();
    }
    
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        string psqlConnectionString = configuration.GetConnectionString("PSqlConnectionString")!;

        services.AddDbContext<StreetBiteDbContext>(config =>
            config.UseNpgsql(psqlConnectionString));
    }
}