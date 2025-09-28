using MediatR;

namespace HR_Management.Application.Features.LeaveType.Request.Commands;

public record DeleteLeaveTypeCommandRequest(int id) : IRequest<bool>
{
}
