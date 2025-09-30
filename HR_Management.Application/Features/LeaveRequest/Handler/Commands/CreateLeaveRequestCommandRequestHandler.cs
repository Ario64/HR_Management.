using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequestDTOs.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequest.Request.Commands;
using HR_Management.Application.Infrastructure.Services.EmailService;
using HR_Management.Application.Models;
using HR_Management.Application.UintOfWork;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Commands;

public class CreateLeaveRequestCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender sender) : IRequestHandler<CreateLeaveRequestCommandRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IEmailSender _sender = sender;

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

        var email = new Email() 
        {
             To = "shahrokhi20@yahoo.com",
             Subject = "Leave Request Created",
             Body = $"Your leave request from {request.CreateLeaveRequestDto.StartDate} to {request.CreateLeaveRequestDto.EndDate} has been approved."
        };
        await _sender.SendEmailAsync(email);

        return true;
    }
}
