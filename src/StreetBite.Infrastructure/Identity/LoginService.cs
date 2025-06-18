using Microsoft.AspNetCore.Identity;
using StreetBite.Domain.Security.Tokens;
using StreetBite.Domain.Services.Login.CommonUser;

namespace StreetBite.Infrastructure.Identity;

public class LoginService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAccessTokenGenerator tokenGenerator) : ICommonUserLoginService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly IAccessTokenGenerator _tokenGenerator = tokenGenerator;
    
    public async Task<ResponseLoginJson> LoginAsync(string email, string password)
    {
        var appUser = await _userManager.FindByEmailAsync(email);
        
        var result = await _signInManager.PasswordSignInAsync(appUser, password, false, false);
        
        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Invalid login attempt.");
        }
        
        var roles = await _userManager.GetRolesAsync(appUser);
        
        var domainUser = appUser.ToDomain();
        
        var token = await _tokenGenerator.GenerateAccessTokenAsync(domainUser, roles);
        
        return new ResponseLoginJson
        {
            Message = "Login successful",
            AccessToken = token
        };
    }
}