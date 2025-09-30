using HR_Management.Application.Models;

namespace HR_Management.Application.Infrastructure.Services.EmailService;

public interface IEmailSender
{
     Task<bool> SendEmailAsync(Email email);
}
