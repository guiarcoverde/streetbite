using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StreetBite.Infrastructure.DataAccess;

namespace StreetBite.Infrastructure.Migrations;

public static class DatabaseMigrations
{
    public static async Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<StreetBiteDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}