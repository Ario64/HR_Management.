using HR_Management.Application.Responses;
using HR_Management.Domain.DTOs.LeaveTypeDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveType.Request.Commands;

public record CreateLeaveTypeCommandRequest(CreateLeaveTypeDto CreateLeaveTypeDto) : IRequest<LeaveTypeDto>
{
}
