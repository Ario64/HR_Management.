using HR_Management.Domain.Common;

namespace HR_Management.Domain.Entities;

public class LeaveAllocation : BaseEntity
{
    public int LeaveTypeId { get; set; }
    public int NumberOfDate { get; set; }
    public int Period { get; set; }

    #region Navigation property

    public LeaveType? LeaveType { get; set; }

    #endregion
}