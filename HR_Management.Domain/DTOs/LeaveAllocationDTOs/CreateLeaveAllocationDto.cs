namespace HR_Management.Domain.DTOs.LeaveAllocationDTOs;

public record CreateLeaveAllocationDto
{
    public int LeaveTypeId { get; set; }
    public int NumberOfDate { get; set; }
    public int Period { get; set; }
}