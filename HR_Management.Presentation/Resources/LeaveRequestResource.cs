using HR_Management.Domain.DTOs.LeaveRequestDTOs;
using HR_Management.Presentation.Hatoeas;

namespace HR_Management.Application.DTOs.Resources;

public class LeaveRequestResource : LeaveRequestDto
{
    public List<Link>? Links { get; set; }
}
