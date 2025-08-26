using AutoMapper;
using HR_Management.Domain.DTOs.LeaveAllocationDTOs;

namespace HR_Management.Application.Profiles.LeaveAllocation;

public class LeaveAllocationMappingProfile : Profile
{
    public LeaveAllocationMappingProfile()
    {
        CreateMap<HR_Management.Domain.Entities.LeaveAllocation, LeaveAllocationDto>();
        CreateMap<HR_Management.Domain.Entities.LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
        CreateMap<HR_Management.Domain.Entities.LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();
        CreateMap<HR_Management.Domain.Entities.LeaveAllocation, DeleteLeaveAllocationDto>().ReverseMap();
    }
}
