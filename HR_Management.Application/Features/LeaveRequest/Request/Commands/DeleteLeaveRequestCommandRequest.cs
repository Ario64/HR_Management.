using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Commands;

public record DeleteLeaveRequestCommandRequest(int id) : IRequest<bool>
{
}
