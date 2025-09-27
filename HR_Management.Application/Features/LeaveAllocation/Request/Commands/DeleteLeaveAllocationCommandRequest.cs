using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Request.Commands;

public record DeleteLeaveAllocationCommandRequest(int id) : IRequest<bool>
{
}
