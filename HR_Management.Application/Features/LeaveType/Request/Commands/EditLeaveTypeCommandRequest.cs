using HR_Management.Domain.DTOs.LeaveTypeDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveType.Request.Commands;

public record EditLeaveTypeCommandRequest(EditLeaveTypeDto EditLeaveTypeDto) : IRequest<Unit>
{
}
