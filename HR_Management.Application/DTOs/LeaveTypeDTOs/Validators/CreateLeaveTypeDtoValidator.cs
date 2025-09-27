using FluentValidation;
using HR_Management.Domain.DTOs.LeaveTypeDTOs;

namespace HR_Management.Application.DTOs.LeaveTypeDTOs.Validators;

public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
{
    public CreateLeaveTypeDtoValidator()
    {
        Include(new ILeaveTypeDtoValidator());
    }
}
