using FluentValidation;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveAllocationDTOs;

namespace HR_Management.Application.DTOs.LeaveAllocationDTOs.Validators;

public class CreateLeaveAllocationValidator : AbstractValidator<CreateLeaveAllocationDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateLeaveAllocationValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        Include(new ILeaveAllocationValidator(_unitOfWork));

    }
}
