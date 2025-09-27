using FluentValidation;
using HR_Management.Domain.DTOs.LeaveAllocationDTOs;

namespace HR_Management.Application.DTOs.LeaveAllocationDTOs.Validators;

public class DeleteLeaveAllocationValidator : AbstractValidator<DeleteLeaveAllocationDto>
{
    public DeleteLeaveAllocationValidator()
    {
        RuleFor(r => r.LeaveAllocationId).NotEmpty()
                                         .WithMessage("{PropertyName} is required !")
                                         .GreaterThan(0)
                                         .WithMessage("{PropertyName} must be greater than 0 !");
    }
}
