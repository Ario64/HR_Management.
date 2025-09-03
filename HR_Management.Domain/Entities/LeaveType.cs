using HR_Management.Domain.Common;

namespace HR_Management.Domain.Entities;

public class LeaveType : BaseEntity
{
    public required string LeaveTypeTitle { get; set; }
    public int DefaultDays { get; set; }

    #region Navigation properties

    public ICollection<LeaveRequest>? LeaveRequests { get; set; }
    public ICollection<LeaveAllocation>? LeaveAllocations { get; set; }

    #endregion

}
