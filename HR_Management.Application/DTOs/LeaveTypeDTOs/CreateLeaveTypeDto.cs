namespace HR_Management.Domain.DTOs.LeaveTypeDTOs;

public record CreateLeaveTypeDto
{
    public required string LeaveTypeTitle { get; set; }
    public int DefaultDays { get; set; }
}