using HR_Management.Application.DTOs.LeaveTypeDTOs;

namespace HR_Management.Domain.DTOs.LeaveTypeDTOs;

public record LeaveTypeDto : ILeaveTypeDto
{
    public int Id { get; set; }
    public required string LeaveTypeTitle { get; set; }
    public int DefaultDays { get; set; }
}