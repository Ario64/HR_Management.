using FluentValidation;
using HR_Management.Domain.DTOs.LeaveTypeDTOs;

namespace HR_Management.Application.DTOs.LeaveTypeDTOs.Validators;

public class EditLeaveTypeDtoValidator : AbstractValidator<EditLeaveTypeDto>
{
    public EditLeaveTypeDtoValidator()
    {
        Include(new ILeaveTypeDtoValidator());

        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} is required !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} must be greater than 0 !");
    }
}
