using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequestDTOs.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Hatoeas;
using HR_Management.Application.Infrastructure.Services.EmailService;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveRequestDTOs;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequest.Handler.Commands;

public class CreateLeaveRequestCommandRequestHandler : IRequestHandler<CreateLeaveRequestCommandRequest, LeaveRequestDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmailSender _sender;

    public CreateLeaveRequestCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender sender)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _sender = sender;
    }

    public async Task<LeaveRequestDto> Handle(CreateLeaveRequestCommandRequest request, CancellationToken cancellationToken)
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

        var mappedLeaveRequestDto = _mapper.Map<LeaveRequestDto>(mappedLeaveRequest);

        var email = new Email()
        {
            To = "shahrokhi20@yahoo.com",
            Subject = "Leave Request Created",
            Body = $"Your leave request from {request.CreateLeaveRequestDto.StartDate} to {request.CreateLeaveRequestDto.EndDate} has been approved."
        };
        await _sender.SendEmailAsync(email);

        return mappedLeaveRequestDto;
    }
}
