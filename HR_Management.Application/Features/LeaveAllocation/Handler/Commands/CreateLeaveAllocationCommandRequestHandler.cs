using AutoMapper;
using HR_Management.Application.Features.LeaveAllocation.Request.Commands;
using HR_Management.Application.UintOfWork;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Handler.Commands;

public class CreateLeaveAllocationCommandRequestHandler : IRequestHandler<CreateLeaveAllocationCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CreateLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = _mapper.Map<HR_Management.Domain.Entities.LeaveAllocation>(request.createLeaveAllocationDto);
        _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveAllocation>().Add(leaveAllocation);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
