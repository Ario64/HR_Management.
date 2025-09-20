using FluentValidation;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveAllocationDTOs;

namespace HR_Management.Application.DTOs.LeaveAllocationDTOs.Validators;

public class EditLeaveAllocationValidator : AbstractValidator<UpdateLeaveAllocationDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public EditLeaveAllocationValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        Include(new ILeaveAllocationValidator(_unitOfWork));
    }
}
