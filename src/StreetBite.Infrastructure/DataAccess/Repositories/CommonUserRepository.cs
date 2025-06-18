using Microsoft.AspNetCore.Identity;
using StreetBite.Domain.Entities.Users;
using StreetBite.Domain.Repositories.Users.CommonUser;
using StreetBite.Infrastructure.Identity;

namespace StreetBite.Infrastructure.DataAccess.Repositories;

public class CommonUserRepository(UserManager<ApplicationUser> userManager) : ICommonUserWriteOnlyRepository
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task Add(CommonUser commonUser)
    {
        var appUser = ApplicationUser.FromDomain(commonUser);
        var result = await _userManager.CreateAsync(appUser, commonUser.Password);
        
        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }
        
        var user = await _userManager.FindByEmailAsync(appUser.Email);
        var roleResult = await _userManager.AddToRoleAsync(user, "Common");
        
        if (!roleResult.Succeeded)
        {
            throw new InvalidOperationException("Failed to assign role: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));
        }
    }

    public async Task Delete(CommonUser commonUser)
    {
    }
}