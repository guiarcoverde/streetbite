using Microsoft.AspNetCore.Identity;

namespace StreetBite.Infrastructure.Identity;

public class RoleSeeder
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleSeeder(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task SeedRolesAsync()
    {
        string[] roles = { "Admin", "Common", "Restaurant" };
        
        foreach (var role in roles)
        {
            if (await _roleManager.RoleExistsAsync(role)) continue;
            var identityRole = new IdentityRole(role);
            await _roleManager.CreateAsync(identityRole);
        }
    }
}