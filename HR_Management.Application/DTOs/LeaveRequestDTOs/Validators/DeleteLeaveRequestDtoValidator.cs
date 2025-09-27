using FluentValidation;
using HR_Management.Domain.DTOs.LeaveRequestDTOs;

namespace HR_Management.Application.DTOs.LeaveRequestDTOs.Validators;

public class DeleteLeaveRequestDtoValidator : AbstractValidator<DeleteLeaveRequestDto>
{
    public DeleteLeaveRequestDtoValidator()
    {
        RuleFor(r => r.Id).NotEmpty()
                          .WithMessage("{PropertyName} is reqiured !")
                          .GreaterThan(0)
                          .WithMessage("{PropertyName} must be greater than 0 !");
    }
}
