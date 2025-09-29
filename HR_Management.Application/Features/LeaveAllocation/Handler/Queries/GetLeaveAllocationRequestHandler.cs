using AutoMapper;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveAllocation.Request.Queries;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveAllocationDTOs;
using HR_Management.Domain.Entities;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Handler.Queries;

public class GetLeaveAllocationRequestHandler : IRequestHandler<GetLeaveAllocationRequest, LeaveAllocationDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLeaveAllocationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveAllocation>()
                                               .GetByIdAsync(request.id, cancellationToken);
        if (leaveAllocation == null)
        {
            throw new NotFoundException(nameof(LeaveAllocation), request.id);
        }

        var mappedLeaveAllocation = _mapper.Map<LeaveAllocationDto>(leaveAllocation);

        return mappedLeaveAllocation;
    }
}
