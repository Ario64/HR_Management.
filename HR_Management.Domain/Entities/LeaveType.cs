using HR_Management.Domain.Common;

namespace HR_Management.Domain.Entities;

public class LeaveType : BaseEntity
{
    public required string LeaveTypeTitle { get; set; }
    public int DefaultDays { get; set; }
}
