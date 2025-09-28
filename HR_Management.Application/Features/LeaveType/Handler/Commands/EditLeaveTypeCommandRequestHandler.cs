using AutoMapper;
using HR_Management.Application.Features.LeaveType.Request.Commands;
using HR_Management.Application.UintOfWork;
using MediatR;

namespace HR_Management.Application.Features.LeaveType.Handler.Commands;

public class EditLeaveTypeCommandRequestHandler : IRequestHandler<EditLeaveTypeCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EditLeaveTypeCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(EditLeaveTypeCommandRequest request, CancellationToken cancellationToken)
    {
        var leaveType = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveType>()
                                         .GetByIdAsync(request.EditLeaveTypeDto.Id, cancellationToken);

        _mapper.Map(request.EditLeaveTypeDto, leaveType);
        _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveType>().Update(leaveType);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
