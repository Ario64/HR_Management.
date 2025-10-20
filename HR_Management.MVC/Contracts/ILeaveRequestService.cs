using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Contracts;

public interface ILeaveRequestService
{
    Task<List<LeaveRequestViewModel>> GetLeaveRequestsAsync();
    Task<LeaveRequestViewModel> GetLeaveRequestDetailsAsync(int id);
    Task<Response<int>> CreateLeaveRequestAsync(CreateLeaveRequestViewModel leaveRequest);
    Task<Response<int>> UpdateLeaveRequest(int id, LeaveRequestViewModel leaveRequest);
    Task<Response<int>> DeleteLeaveRequest(int id);
}
