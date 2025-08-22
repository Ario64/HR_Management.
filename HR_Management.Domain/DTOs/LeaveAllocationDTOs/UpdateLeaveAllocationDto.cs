namespace HR_Management.Domain.DTOs.LeaveAllocationDTOs;

public record UpdateLeaveAllocationDto
{
    public int LeaveAllocationId { get; set; }
    public int LeaveTypeId { get; set; }
    public int NumberOfDate { get; set; }
    public int Period { get; set; }
}