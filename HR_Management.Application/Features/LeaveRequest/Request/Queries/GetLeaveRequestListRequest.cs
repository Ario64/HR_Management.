using HR_Management.Domain.DTOs.LeaveRequestDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Request.Queries;

public record GetLeaveRequestListRequest : IRequest<IReadOnlyList<LeaveRequestDto>>
{
}
