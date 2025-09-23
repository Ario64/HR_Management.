using AutoMapper;
using HR_Management.Domain.DTOs.LeaveTypeDTOs;

namespace HR_Management.Application.Profiles.LeaveType;

public class LeaveTypeMappingProfile : Profile
{
    public LeaveTypeMappingProfile() 
    {
        CreateMap<HR_Management.Domain.Entities.LeaveType, LeaveTypeDto>();
        CreateMap<HR_Management.Domain.Entities.LeaveType, CreateLeaveTypeDto>().ReverseMap();
        CreateMap<HR_Management.Domain.Entities.LeaveType, EditLeaveTypeDto>().ReverseMap();
        CreateMap<HR_Management.Domain.Entities.LeaveType, DeleteLeaveTypeDto>().ReverseMap();
    }

}
