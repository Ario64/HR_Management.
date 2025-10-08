using HR_Management.Domain.DTOs.LeaveAllocationDTOs;
using HR_Management.Presentation.Hatoeas;

namespace HR_Management.Application.DTOs.Resources;

public record LeaveAllocationResource : LeaveAllocationDto
{
    public List<Link>? Links { get; set; }
}
