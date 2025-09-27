using HR_Management.Application.DTOs.LeaveAllocationDTOs;

namespace HR_Management.Domain.DTOs.LeaveAllocationDTOs;

public record CreateLeaveAllocationDto : ILeaveAllocationDto
{
    public int LeaveTypeId { get; set; }
    public int NumberOfDate { get; set; }
    public int Period { get; set; }
}