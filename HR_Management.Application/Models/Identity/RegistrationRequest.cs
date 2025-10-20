using System.ComponentModel.DataAnnotations;

namespace HR_Management.Application.Models.Identity;

public class RegistrationRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    [EmailAddress]
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }

    [Compare("Password", ErrorMessage = "Password does not match !")]
    public required string ConfirmPassword { get; set; }
}
