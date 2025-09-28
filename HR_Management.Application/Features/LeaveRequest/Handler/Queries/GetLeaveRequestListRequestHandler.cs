using AutoMapper;
using HR_Management.Application.Features.LeaveRequest.Request.Queries;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveRequestDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Queries;

public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, IReadOnlyList<LeaveRequestDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLeaveRequestListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<LeaveRequestDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
    {
        var leaveRequestList = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveRequest>()
                                                .GetAllAsync(cancellationToken);

        var mappedLeaveRequestList = _mapper.Map<IReadOnlyList<LeaveRequestDto>>(leaveRequestList);

        return mappedLeaveRequestList;
    }
}
