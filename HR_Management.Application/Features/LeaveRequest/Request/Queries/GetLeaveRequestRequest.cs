using HR_Management.Domain.DTOs.LeaveRequestDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Queries;

public record GetLeaveRequestRequest(int id) : IRequest<LeaveRequestDto>
{

}
