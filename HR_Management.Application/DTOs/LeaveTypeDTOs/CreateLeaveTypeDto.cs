using HR_Management.Application.DTOs.LeaveTypeDTOs;

namespace HR_Management.Domain.DTOs.LeaveTypeDTOs;

public record CreateLeaveTypeDto : ILeaveTypeDto
{
    public required string LeaveTypeTitle { get; set; }
    public int DefaultDays { get; set; }
}