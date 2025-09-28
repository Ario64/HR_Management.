using AutoMapper;
using HR_Management.Application.Features.LeaveAllocation.Request.Commands;
using HR_Management.Application.UintOfWork;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Handler.Commands;

public class DeleteLeaveAllocationCommandRequestHandler : IRequestHandler<DeleteLeaveAllocationCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteLeaveAllocationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveAllocation>()
                                               .GetByIdAsync(request.id, cancellationToken);

        if (leaveAllocation != null)
        {
            _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveAllocation>()
                                                       .Remove(leaveAllocation);
        }

        return true;
    }
}