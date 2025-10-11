using HR_Management.Application.DTOs.Common;
using HR_Management.Application.DTOs.LeaveAllocationDTOs;

namespace HR_Management.Domain.DTOs.LeaveAllocationDTOs;

public record LeaveAllocationDto : BaseDto, ILeaveAllocationDto
{
    public int LeaveTypeId { get; set; }
    public int NumberOfDate { get; set; }
    public int Period { get; set; }
}