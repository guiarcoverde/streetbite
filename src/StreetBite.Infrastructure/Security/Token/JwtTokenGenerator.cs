using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StreetBite.Domain.Entities.Users;
using StreetBite.Domain.Security.Tokens;
using StreetBite.Infrastructure.Identity;

namespace StreetBite.Infrastructure.Security.Token;

public class JwtTokenGenerator(uint expirationTimeMinutes, string signingKey) : IAccessTokenGenerator
{
    private readonly uint _expirationTimeMinutes = expirationTimeMinutes;
    private readonly string _signingKey = signingKey;
    
    public async Task<string> GenerateAccessTokenAsync(CommonUser user, IList<string> roles)
    {
        var appUser = ApplicationUser.FromDomain(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, appUser.Email!),
            new Claim(ClaimTypes.Sid, appUser.Id)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        var credentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
            SigningCredentials = credentials
        };
        
        var handler = new JwtSecurityTokenHandler();
        
        var token = handler.CreateToken(tokenDescriptor);
        
        return handler.WriteToken(token);
    }

    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.UTF8.GetBytes(_signingKey);
        
        return new SymmetricSecurityKey(key);
    }
}