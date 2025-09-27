using HR_Management.Domain.DTOs.LeaveAllocationDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Request.Commands;

public record CreateLeaveAllocationCommandRequest(CreateLeaveAllocationDto createLeaveAllocationDto) : IRequest<bool>
{

}
