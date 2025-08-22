using HR_Management.Domain.Common;

namespace HR_Management.Domain.Entities;

public class LeaveRequest : BaseEntity
{
    public int LeaveTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime DateRequest { get; set; }
    public string? RequestComment { get; set; }
    public DateTime ActionDate { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }

    #region Nvigation property

    public LeaveType? LeaveType { get; set; }

    #endregion
}