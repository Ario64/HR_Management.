using HR_Management.Application.Models.Identity;

namespace HR_Management.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}
