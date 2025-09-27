using FluentValidation;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveRequestDTOs;

namespace HR_Management.Application.DTOs.LeaveRequestDTOs.Validators;

public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateLeaveRequestDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        Include(new ILeaveRequestDtoValidator(_unitOfWork));   

    }
}
