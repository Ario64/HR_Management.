using AutoMapper;
using HR_Management.Application.Features.LeaveType.Request.Commands;
using HR_Management.Application.UintOfWork;
using MediatR;

namespace HR_Management.Application.Features.LeaveType.Handler.Commands;

public class CreateLeaveTypeCommandRequestHandler : IRequestHandler<CreateLeaveTypeCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
    {
        var mappedLeaveType = _mapper.Map<HR_Management.Domain.Entities.LeaveType>(request.CreateLeaveTypeDto);
        _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveType>().Add(mappedLeaveType);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
