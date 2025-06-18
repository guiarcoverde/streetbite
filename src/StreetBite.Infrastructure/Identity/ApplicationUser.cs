using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using StreetBite.Domain.Entities;

namespace StreetBite.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    [StringLength(25, ErrorMessage = "The string value cannot exceed 25 characters. ")]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(25, ErrorMessage = "The string value cannot exceed 25 characters. ")]
    public string LastName { get; set; } = string.Empty;
    [StringLength(50, ErrorMessage = "The string value cannot exceed 25 characters. ")]
    public string Address { get; set; } = string.Empty;
    [StringLength(20, ErrorMessage = "The string value cannot exceed 25 characters. ")]
    public string City { get; set; } = string.Empty;
    [StringLength(20, ErrorMessage = "The string value cannot exceed 25 characters. ")]
    public string State { get; set; } = string.Empty;
    public long ZipCode { get; set; }
    public long Cpf { get; set; }
    
    public static ApplicationUser FromDomain(User domainUser)
    {
        return new ApplicationUser
        {
            Id = domainUser.Id.ToString(),
            Email = domainUser.Email,
            UserName = domainUser.Email,
            PasswordHash = domainUser.Password,
            FirstName = domainUser.FirstName,
            LastName = domainUser.LastName,
            PhoneNumber = domainUser.Phone,
            Address = domainUser.Address,
            City = domainUser.City,
            State = domainUser.State,
            ZipCode = domainUser.ZipCode,
            Cpf = domainUser.Cpf,
        };
    }
    
    public User ToDomain()
    {
        return new User
        {
            Id = Guid.Parse(Id),
            Email = this.Email!,
            FirstName = this.FirstName,
            LastName = this.LastName,
        };
    }
}