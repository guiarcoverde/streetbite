using Microsoft.AspNetCore.Identity;
using StreetBite.Domain.Entities.Users;
using StreetBite.Domain.Repositories.Users.CommonUser;
using StreetBite.Domain.Services.Login.CommonUser;
using StreetBite.Infrastructure.Identity;

namespace StreetBite.Infrastructure.DataAccess.Repositories;

public class CommonUserRepository(UserManager<ApplicationUser> userManager)
    : ICommonUserWriteOnlyRepository, ICommonUserReadOnlyRepository
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task Add(CommonUser commonUser)
    {
        var appUser = ApplicationUser.FromDomain(commonUser);
        var result = await _userManager.CreateAsync(appUser, commonUser.Password);

        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Failed to create user: " +
                                                string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        if (string.IsNullOrEmpty(appUser.Email))
        {
            throw new InvalidOperationException("Email cannot be null or empty.");
        }

        var user = await _userManager.FindByEmailAsync(appUser.Email);

        if (user == null)
        {
            throw new InvalidOperationException("User not found after creation.");
        }

        var roleResult = await _userManager.AddToRoleAsync(user, "Common");

        if (!roleResult.Succeeded)
        {
            throw new InvalidOperationException("Failed to assign role: " +
                                                string.Join(", ", roleResult.Errors.Select(e => e.Description)));
        }
    }

    public async Task Delete(CommonUser commonUser)
    {
        var appUser = await _userManager.FindByIdAsync(commonUser.Id.ToString());
        if (appUser == null)
        {
            throw new InvalidOperationException("User not found.");
        }

        var result = await _userManager.DeleteAsync(appUser);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Failed to delete user: " +
                                                string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        var roles = await _userManager.GetRolesAsync(appUser);
        foreach (var role in roles)
        {
            var roleResult = await _userManager.RemoveFromRoleAsync(appUser, role);
            if (!roleResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to remove user from role: " +
                                                    string.Join(", ", roleResult.Errors.Select(e => e.Description)));
            }
        }
    }


    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return false;
        }

        return true;
    }

    public async Task<CommonUser> GetCommonUserByEmail(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            throw new InvalidOperationException("User not found.");
        }

        var domainUser = new ApplicationUser().ToDomain();

        return domainUser;
    }

}