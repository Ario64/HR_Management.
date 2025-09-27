namespace HR_Management.Application.DTOs.LeaveTypeDTOs;

public interface ILeaveTypeDto
{
    public string LeaveTypeTitle { get; set; }
    public int DefaultDays { get; set; }
}
