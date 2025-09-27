using FluentValidation;

namespace HR_Management.Application.DTOs.LeaveTypeDTOs.Validators;

public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
{
    public ILeaveTypeDtoValidator()
    {
        RuleFor(r => r.LeaveTypeTitle).NotEmpty()
                                      .WithMessage("{PropertyName} is required !")
                                      .MaximumLength(300)
                                      .WithMessage("{PropertyName} must be 300 characters !");

        RuleFor(r => r.DefaultDays).NotEmpty()
                                   .WithMessage("{PropertyName} is required !")
                                   .GreaterThan(0)
                                   .WithMessage("{PropertyName} must be greater than 0 !");
    }
}