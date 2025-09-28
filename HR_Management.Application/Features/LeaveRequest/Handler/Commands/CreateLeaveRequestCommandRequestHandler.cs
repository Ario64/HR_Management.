using AutoMapper;
using HR_Management.Application.Features.LeaveRequest.Request.Commands;
using HR_Management.Application.UintOfWork;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Commands;

public class CreateLeaveRequestCommandRequestHandler : IRequestHandler<CreateLeaveRequestCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLeaveRequestCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateLeaveRequestCommandRequest request, CancellationToken cancellationToken)
    {
        var mappedLeaveRequest = _mapper.Map<HR_Management.Domain.Entities.LeaveRequest>(request.CreateLeaveRequestDto);

        _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveRequest>().Add(mappedLeaveRequest);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;                               
    }
}
