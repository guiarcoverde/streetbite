using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using StreetBite.Domain.Entities;
using StreetBite.Domain.Entities.Users;

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
    
    public static ApplicationUser FromDomain(CommonUser domainCommonUser)
    {
        return new ApplicationUser
        {
            Id = domainCommonUser.Id.ToString(),
            Email = domainCommonUser.Email,
            UserName = domainCommonUser.Email,
            PasswordHash = domainCommonUser.Password,
            FirstName = domainCommonUser.FirstName,
            LastName = domainCommonUser.LastName,
            PhoneNumber = domainCommonUser.Phone,
            Address = domainCommonUser.Address,
            City = domainCommonUser.City,
            State = domainCommonUser.State,
            ZipCode = domainCommonUser.ZipCode,
            Cpf = domainCommonUser.Cpf,
        };
    }
    
    public CommonUser ToDomain()
    {
        return new CommonUser
        {
            Id = Guid.Parse(Id),
            Email = this.Email!,
            FirstName = this.FirstName,
            LastName = this.LastName,
        };
    }
}