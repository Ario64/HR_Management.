using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services;

public class LeaveRequestService : ILeaveRequestService
{
    public Task<Response<int>> CreateLeaveRequestAsync(CreateLeaveRequestViewModel leaveRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Response<int>> DeleteLeaveRequest(int id)
    {
        throw new NotImplementedException();
    }

    public Task<LeaveRequestViewModel> GetLeaveRequestDetailsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveRequestViewModel>> GetLeaveRequestsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<int>> UpdateLeaveRequest(int id, LeaveRequestViewModel leaveRequest)
    {
        throw new NotImplementedException();
    }
}
