using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Request.Commands;

public record DeleteLeaveRequestCommandRequest(int id) : IRequest<bool>
{
}
