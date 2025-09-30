using HR_Management.Application.Infrastructure.Services.EmailService;
using HR_Management.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace HR_Management.Infrastructure.Services.Email;

public class EmailSender : IEmailSender
{
    private EmailSetting _emailSetting;

    public EmailSender(IOptions<EmailSetting> emailSetting)
    {
        _emailSetting = emailSetting.Value;
    }

    public async Task<bool> SendEmailAsync(Application.Models.Email email)
    {
        var client = new SendGridClient(_emailSetting.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress(_emailSetting.SenderAddress, _emailSetting.SenderName);
        var msg = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(msg);

        return response.StatusCode == HttpStatusCode.OK ||
               response.StatusCode == HttpStatusCode.Accepted;
    }
}
