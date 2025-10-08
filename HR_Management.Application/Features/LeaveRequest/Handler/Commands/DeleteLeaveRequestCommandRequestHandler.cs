using AutoMapper;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequest.Handler.Commands;
using HR_Management.Application.UintOfWork;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Commands;

public class DeleteLeaveRequestCommandRequestHandler : IRequestHandler<DeleteLeaveRequestCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLeaveRequestCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteLeaveRequestCommandRequest request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveRequest>()
                                            .GetByIdAsync(request.id, cancellationToken);
        if (leaveRequest == null) 
        {
            throw new NotFoundException(nameof(LeaveRequest), request.id);
        }
        _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveRequest>().Remove(leaveRequest);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
