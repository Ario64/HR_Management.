using HR_Management.Application.Hatoeas;

namespace HR_Management.Application.Infrastructure.Services.EmailService;

public interface IEmailSender
{
     Task<bool> SendEmailAsync(Email email);
}
