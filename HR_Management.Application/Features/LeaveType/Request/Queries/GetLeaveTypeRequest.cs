using HR_Management.Domain.DTOs.LeaveTypeDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveType.Request.Queries;

public record GetLeaveTypeRequest(int id) : IRequest<LeaveTypeDto>
{
}
