using AutoMapper;
using HR_Management.Application.Features.LeaveAllocation.Request.Queries;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveAllocationDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Handler.Queries;

public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, IReadOnlyList<LeaveAllocationDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetLeaveAllocationListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocationList = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveAllocation>()
                                                   .GetAllAsync(cancellationToken);

        var mappedLeaveAllocationList = _mapper.Map<IReadOnlyList<LeaveAllocationDto>>(leaveAllocationList);

        return mappedLeaveAllocationList;
    }
}
