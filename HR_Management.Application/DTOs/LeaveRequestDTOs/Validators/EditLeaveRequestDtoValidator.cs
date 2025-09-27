using FluentValidation;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveRequestDTOs;

namespace HR_Management.Application.DTOs.LeaveRequestDTOs.Validators;

public class EditLeaveRequestDtoValidator : AbstractValidator<EditLeaveRequestDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public EditLeaveRequestDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        Include(new ILeaveRequestDtoValidator(_unitOfWork));

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} is required !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} must be greater than 0 !");
    }
}
