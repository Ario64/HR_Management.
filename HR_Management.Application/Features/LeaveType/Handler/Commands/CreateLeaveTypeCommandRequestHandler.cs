using AutoMapper;
using HR_Management.Application.DTOs.LeaveTypeDTOs.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveType.Request.Commands;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveTypeDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveType.Handler.Commands;

public class CreateLeaveTypeCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateLeaveTypeCommandRequest, LeaveTypeDto>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<LeaveTypeDto> Handle(CreateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDto, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }

        var mappedLeaveType = _mapper.Map<HR_Management.Domain.Entities.LeaveType>(request.CreateLeaveTypeDto);
        _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveType>().Add(mappedLeaveType);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<LeaveTypeDto>(mappedLeaveType);
    }
}
