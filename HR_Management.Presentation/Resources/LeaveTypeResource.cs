using HR_Management.Domain.DTOs.LeaveTypeDTOs;
using HR_Management.Presentation.Hatoeas;

namespace HR_Management.Presentation.Models.Resources
{
    public record LeaveTypeResource : LeaveTypeDto
    {
        public List<Link>? Links { get; set; } = new();
    }
}
