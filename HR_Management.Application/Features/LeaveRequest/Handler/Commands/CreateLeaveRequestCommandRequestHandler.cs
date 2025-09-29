using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequestDTOs.Validators;
using HR_Management.Application.Exceptions;
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
        var validator = new CreateLeaveRequestDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto, cancellationToken);

        if (!validationResult.IsValid) 
        {
            throw new ValidationException(validationResult);
        }

        var mappedLeaveRequest = _mapper.Map<HR_Management.Domain.Entities.LeaveRequest>(request.CreateLeaveRequestDto);

        _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveRequest>().Add(mappedLeaveRequest);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
