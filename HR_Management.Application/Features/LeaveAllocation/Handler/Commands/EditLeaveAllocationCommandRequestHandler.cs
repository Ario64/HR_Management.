using AutoMapper;
using HR_Management.Application.Features.LeaveAllocation.Request.Commands;
using HR_Management.Application.UintOfWork;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Handler.Commands;

public class EditLeaveAllocationCommandRequestHandler : IRequestHandler<EditLeaveAllocationCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EditLeaveAllocationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(EditLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveAllocation>()
                                               .GetByIdAsync(request.id, cancellationToken);

        if (leaveAllocation != null)
        {
            _mapper.Map(leaveAllocation, request.EditLeaveAllocationDto);
            _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveAllocation>().Update(leaveAllocation);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        return true;
    }
}
