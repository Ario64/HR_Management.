namespace HR_Management.Application.DTOs.LeaveRequestDTOs;

public interface ILeaveRequestDto
{
    int LeaveTypeId { get; set; }
    DateTime StartDate { get; set; }
    DateTime EndDate { get; set; }
    DateTime DateRequest { get; set; }
    string? RequestComment { get; set; }
    DateTime ActionDate { get; set; }
}
