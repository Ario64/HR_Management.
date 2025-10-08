using HR_Management.Application.Infrastructure.Services.EmailService;
using HR_Management.Application.Hatoeas;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace HR_Management.Infrastructure.Services.Email;

public class EmailSender : IEmailSender
{
    private EmailSetting _emailSetting;

    public EmailSender(IOptions<EmailSetting> emailSetting)
    {
        _emailSetting = emailSetting.Value;
    }

    public async Task<bool> SendEmailAsync(Application.Hatoeas.Email email)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress( _emailSetting.SenderName, _emailSetting.SenderAddress));
        message.To.Add(MailboxAddress.Parse(email.To));
       message.Subject = email.Subject;
        message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = email.Body };

        var client = new SmtpClient();
        await client.ConnectAsync(_emailSetting.MailServer, _emailSetting.MailPort, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_emailSetting.SenderAddress, _emailSetting.SenderPassword);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);

        return true;    
    }
}
