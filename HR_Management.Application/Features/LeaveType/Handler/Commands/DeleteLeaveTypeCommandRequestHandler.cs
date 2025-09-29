using AutoMapper;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveType.Request.Commands;
using HR_Management.Application.UintOfWork;
using MediatR;

namespace HR_Management.Application.Features.LeaveType.Handler.Commands;

public class DeleteLeaveTypeCommandRequestHandler : IRequestHandler<DeleteLeaveTypeCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLeaveTypeCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteLeaveTypeCommandRequest request, CancellationToken cancellationToken)
    {
        var leaveType = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveType>()
                                   .GetByIdAsync(request.id, cancellationToken);

        if (leaveType == null)
        {
            throw new NotFoundException(nameof(HR_Management.Domain.Entities.LeaveType), request.id);
        }

        _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveType>().Remove(leaveType);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
