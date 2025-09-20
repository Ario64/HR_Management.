using FluentValidation;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.DTOs.LeaveAllocationDTOs;
using HR_Management.Domain.Entities;

namespace HR_Management.Application.DTOs.LeaveAllocationDTOs.Validators;

public class ILeaveAllocationValidator : AbstractValidator<ILeaveAllocationDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public ILeaveAllocationValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(r => r.Period).NotEmpty()
                              .WithMessage("{PropertyName} is required !")
                              .GreaterThan(0)
                              .WithMessage("{PropertyName} must be greater than 0 !");

        RuleFor(r => r.NumberOfDate).NotEmpty()
                                    .WithMessage("{PropertyName} is required !")
                                    .GreaterThan(0)
                                    .WithMessage("{PropertyName} must be greater than 0 !");

        RuleFor(r => r.LeaveTypeId).NotEmpty()
                                   .WithMessage("{PropertyName} is required !")
                                   .MustAsync((id, token) =>
                                   {
                                       var leaveAllocation = _unitOfWork.GenericRepository<LeaveAllocation>().IsExist(id);
                                       return leaveAllocation;
                                   })
                                   .WithMessage("{PropertyName} does not exist !");
    }
}
