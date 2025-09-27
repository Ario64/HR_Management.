using HR_Management.Application.DTOs.Common;
using HR_Management.Application.DTOs.LeaveAllocationDTOs;

namespace HR_Management.Domain.DTOs.LeaveAllocationDTOs;

public class EditLeaveAllocationDto : BaseDto, ILeaveAllocationDto
{
    public int LeaveAllocationId { get; set; }
    public int LeaveTypeId { get; set; }
    public int NumberOfDate { get; set; }
    public int Period { get; set; }
}