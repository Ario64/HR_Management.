using System.Security.AccessControl;

namespace HR_Management.Domain.DTOs.LeaveTypeDTOs;

public record EditLeaveTypeDto
{
    public int  LeaveTypeId { get; set; }
    public required string LeaveTypeTitle { get; set; }
    public int DefaultDays { get; set; }
}