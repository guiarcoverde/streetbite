using Microsoft.AspNetCore.Identity;
using StreetBite.Domain.Entities;

namespace StreetBite.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public long Cpf { get; set; }
    
    public static ApplicationUser FromDomain(User domainUser)
    {
        return new ApplicationUser
        {
            Id = domainUser.Id,
            Email = domainUser.Email,
            UserName = domainUser.Email,
            FirstName = domainUser.FirstName,
            LastName = domainUser.LastName,
            Phone = domainUser.Phone,
            Address = domainUser.Address,
            City = domainUser.City,
            State = domainUser.State,
            ZipCode = domainUser.ZipCode,
            Cpf = domainUser.Cpf
        };
    }
    
    public User ToDomain()
    {
        return new User
        {
            Id = this.Id,
            Email = this.Email!,
            FirstName = this.FirstName,
            LastName = this.LastName,
        };
    }
}