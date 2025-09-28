using AutoMapper;
using HR_Management.Application.Features.LeaveType.Request.Queries;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveTypeDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveType.Handler.Queries;

public class GetLeaveTypeRequestHandler : IRequestHandler<GetLeaveTypeRequest, LeaveTypeDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLeaveTypeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LeaveTypeDto> Handle(GetLeaveTypeRequest request, CancellationToken cancellationToken)
    {
        var leaveType = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveType>()
                                         .GetByIdAsync(request.id, cancellationToken);

        var mappedLeaveType = _mapper.Map<LeaveTypeDto>(leaveType);
        return mappedLeaveType;
    }
}
