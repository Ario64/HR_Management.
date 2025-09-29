using AutoMapper;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveType.Request.Queries;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveTypeDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveType.Handler.Queries;

public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, IReadOnlyList<LeaveTypeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLeaveTypeListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
    {
        var leaveTypeList = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveType>()
                                             .GetAllAsync(cancellationToken);

        if (leaveTypeList == null) 
        {
            throw new ListNullException();
        }

        var mappedLeaveTypeList = _mapper.Map<IReadOnlyList<LeaveTypeDto>>(leaveTypeList);

        return mappedLeaveTypeList;
    }
}
