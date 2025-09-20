namespace HR_Management.Application.DTOs.LeaveAllocationDTOs;

public interface ILeaveAllocationDto
{
    public int LeaveTypeId { get; set; }
    public int NumberOfDate { get; set; }
    public int Period { get; set; }
}
