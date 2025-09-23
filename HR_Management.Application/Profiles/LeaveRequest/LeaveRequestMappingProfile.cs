using AutoMapper;
using HR_Management.Domain.DTOs.LeaveRequestDTOs;

namespace HR_Management.Application.Profiles.LeaveRequest;

public class LeaveRequestMappingProfile : Profile
{
    public LeaveRequestMappingProfile()
    {
        CreateMap<HR_Management.Domain.Entities.LeaveRequest, LeaveRequestDto>();
        CreateMap<HR_Management.Domain.Entities.LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
        CreateMap<HR_Management.Domain.Entities.LeaveRequest, EditLeaveRequestDto>().ReverseMap();
        CreateMap<HR_Management.Domain.Entities.LeaveRequest, DeleteLeaveRequestDto>().ReverseMap();
    }
}
