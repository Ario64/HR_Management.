namespace HR_Management.Domain.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
}