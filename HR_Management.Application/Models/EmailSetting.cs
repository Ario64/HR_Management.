namespace HR_Management.Application.Models;

public class EmailSetting
{
    public string? SenderAddress { get; set; }
    public string? SenderPassword { get; set; }
    public string? SenderName { get; set; }
    public string? MailServer { get; set; }
    public int MailPort { get; set; }
}
