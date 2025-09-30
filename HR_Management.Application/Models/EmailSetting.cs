namespace HR_Management.Application.Models;

public class EmailSetting
{
    public required string  ApiKey { get; set; }
    public required string SenderAddress { get; set; }
    public required string SenderName { get; set; }
}
