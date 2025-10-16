using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Contracts;

public interface ILeaveAllocationService
{
    Task<List<LeaveAllocationViewModel>> GetLeaveAllocationsAsync();
    Task<LeaveAllocationViewModel> GetLeaveAllocationDetailsAsync(int id);
    Task<Response<int>> CreateLeaveAllocationAsync(CreateLeaveAllocationViewModel leaveAllocation);
    Task<Response<int>> UpdateLeaveAllocation(int id, LeaveAllocationViewModel leaveAllocation);
    Task<Response<int>> DeleteLeaveAllocation(int id);
}
