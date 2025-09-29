using AutoMapper;
using HR_Management.Application.DTOs.LeaveAllocationDTOs.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveAllocation.Request.Commands;
using HR_Management.Application.Responses;
using HR_Management.Application.UintOfWork;
using MediatR;

namespace HR_Management.Application.Features.LeaveAllocation.Handler.Commands;

public class CreateLeaveAllocationCommandRequestHandler : IRequestHandler<CreateLeaveAllocationCommandRequest, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveAllocationValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.createLeaveAllocationDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            var exception = new ValidationException(validationResult);
            response.IsSuccessd = false;
            response.Message = "Creation failed !";
            response.Errors = exception.Exceptions;

            return response;
        }

        var leaveAllocation = _mapper.Map<HR_Management.Domain.Entities.LeaveAllocation>(request.createLeaveAllocationDto);
        _unitOfWork.GenericRepository<HR_Management.Domain.Entities.LeaveAllocation>().Add(leaveAllocation);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        response.IsSuccessd = true;
        response.Message = "Creation was successful.";
        return response;
    }
}
