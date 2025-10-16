using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services;

public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
{
    private readonly IMapper _mapper;
    public LeaveAllocationService(IMapper mapper, ILocalStorageService localStorageService, IClient client):base(client, localStorageService)
    {
        _mapper = mapper;
    }

    public Task<Response<int>> CreateLeaveAllocationAsync(CreateLeaveAllocationViewModel leaveAllocation)
    {
        throw new NotImplementedException();
    }

    public Task<Response<int>> DeleteLeaveAllocation(int id)
    {
        throw new NotImplementedException();
    }

    public Task<LeaveAllocationViewModel> GetLeaveAllocationDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveAllocationViewModel>> GetLeaveAllocationsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<int>> UpdateLeaveAllocation(int id, LeaveAllocationViewModel leaveAllocation)
    {
        throw new NotImplementedException();
    }
}
