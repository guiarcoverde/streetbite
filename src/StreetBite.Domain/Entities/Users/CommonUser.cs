namespace StreetBite.Domain.Entities.Users;

public class CommonUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public long Cpf { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public long ZipCode { get; set; }
}