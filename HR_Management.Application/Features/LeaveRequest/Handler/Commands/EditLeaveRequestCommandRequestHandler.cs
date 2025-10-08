using AutoMapper;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequest.Handler.Commands;
using HR_Management.Application.UintOfWork;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Commands;

public class EditLeaveRequestCommandRequestHandler : IRequestHandler<EditLeaveRequestCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EditLeaveRequestCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(EditLeaveRequestCommandRequest request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveRequest>()
                                            .GetByIdAsync(request.EditLeaveRequestDto.Id, cancellationToken);

        if (leaveRequest == null)
        {
            throw new NotFoundException(nameof(LeaveRequest), request.EditLeaveRequestDto.Id);
        }

        _mapper.Map(request.EditLeaveRequestDto, leaveRequest);
        _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveRequest>().Update(leaveRequest!);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
