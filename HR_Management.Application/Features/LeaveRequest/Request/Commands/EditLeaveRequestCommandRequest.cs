using HR_Management.Domain.DTOs.LeaveRequestDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Commands;

public record EditLeaveRequestCommandRequest(EditLeaveRequestDto EditLeaveRequestDto) : IRequest<bool>
{
}
