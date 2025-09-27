using HR_Management.Domain.DTOs.LeaveAllocationDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Request.Queries;

public class GetLeaveAllocationListRequest : IRequest<IReadOnlyList<LeaveAllocationDto>>
{
}
