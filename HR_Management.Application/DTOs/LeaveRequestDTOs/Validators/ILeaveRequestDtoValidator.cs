using FluentValidation;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.Entities;

namespace HR_Management.Application.DTOs.LeaveRequestDTOs.Validators;

public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public ILeaveRequestDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(r => r.StartDate).LessThan(p=>p.EndDate)
                                 .WithMessage("{PropertyName} must be less than {ComparisonValue} !");

        RuleFor(r => r.EndDate).GreaterThan(p=>p.StartDate)
                               .WithMessage("{PropertyName} must be greater than {ComparisonValue} !");

        RuleFor(r => r.LeaveTypeId).NotEmpty()
                                   .WithMessage("{PropertyName} is required !")
                                   .GreaterThan(0)
                                   .WithMessage("{PropertyName} must be greater than 0 !")
                                   .MustAsync((id, token) =>
                                   {
                                       var leaveAllocation = _unitOfWork.GenericRepository<LeaveType>().IsExist(id);
                                       return leaveAllocation;
                                   })
                                   .WithMessage("{PropertyName} does not exist !");
    }
}
