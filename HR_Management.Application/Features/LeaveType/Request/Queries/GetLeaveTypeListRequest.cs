using HR_Management.Domain.DTOs.LeaveTypeDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveType.Request.Queries;

public record GetLeaveTypeListRequest : IRequest<IReadOnlyList<LeaveTypeDto>>
{
}
