using HR_Management.Application.DTOs.Common;

namespace HR_Management.Domain.DTOs.LeaveAllocationDTOs;

public class DeleteLeaveAllocationDto : BaseDto
{
    public int LeaveAllocationId { get; set; }
}