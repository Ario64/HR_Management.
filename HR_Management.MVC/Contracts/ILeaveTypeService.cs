using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Contracts;

public interface ILeaveTypeService
{
    Task<List<LeaveTypeViewModel>> GetLeaveTypesAsync();
    Task<LeaveTypeViewModel> GetLeaveTypeDetailsAsync(int id);
    Task<Response<int>> CreateLeaveTypeAsync(CreateLeaveTypeViewModel leaveType);
    Task<Response<int>> UpdateLeaveType(int id, LeaveTypeViewModel leaveType);
    Task<Response<int>> DeleteLeaveType(int id);
}
