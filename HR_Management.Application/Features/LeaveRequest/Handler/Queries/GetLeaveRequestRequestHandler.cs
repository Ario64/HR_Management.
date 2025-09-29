using AutoMapper;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequest.Request.Queries;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveRequestDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Queries;

public class GetLeaveRequestRequestHandler : IRequestHandler<GetLeaveRequestRequest, LeaveRequestDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLeaveRequestRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LeaveRequestDto> Handle(GetLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveRequest>()
                                            .GetByIdAsync(request.id, cancellationToken);

        if (leaveRequest == null)
        {
            throw new NotFoundException(nameof(HR_Management.Domain.Entities.LeaveRequest), request.id);
        }

        var mappedLeaveRequest = _mapper.Map<LeaveRequestDto>(leaveRequest);
        return mappedLeaveRequest;
    }
}
