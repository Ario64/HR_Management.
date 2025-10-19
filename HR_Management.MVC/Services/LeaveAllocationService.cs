using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services;

public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
{
    private readonly IMapper _mapper;
    public LeaveAllocationService(IMapper mapper, ILocalStorageService localStorageService, IClient client) : base(client, localStorageService)
    {
        _mapper = mapper;
    }

    public async Task<Response<int>> CreateLeaveAllocationAsync(CreateLeaveAllocationViewModel leaveAllocation)
    {
        try
        {
            var response = new Response<int>();
            var createLeaveAllocationDto = _mapper.Map<LeaveAllocationDto>(leaveAllocation);
            var apiResponse = await _client.LeaveAllocationPOSTAsync(createLeaveAllocationDto);
            if (apiResponse != null)
            {
                response.Success = true;
                response.Data = apiResponse.Id;
            }
            else
            {
                response.Success = false;
                response.Message = "Creation failed !";
                response.Data = 0;
            }

            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<Response<int>> DeleteLeaveAllocation(int id)
    {
        try
        {
            await _client.LeaveAllocationDELETEAsync(id);
            return new Response<int> { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }

    public async Task<LeaveAllocationViewModel> GetLeaveAllocationDetailsAsync(int id)
    {
        var response = new Response<int>();
        var leaveAllocation = await _client.LeaveAllocationGETAsync(id);
        return _mapper.Map<LeaveAllocationViewModel>(leaveAllocation);
    }

    public async Task<List<LeaveAllocationViewModel>> GetLeaveAllocationsAsync()
    {
        var leaveAllocations = await _client.LeaveAllocationAllAsync();
        return _mapper.Map<List<LeaveAllocationViewModel>>(leaveAllocations);
    }

    public async Task<Response<int>> UpdateLeaveAllocation(int id, LeaveAllocationViewModel leaveAllocation)
    {
        try {
            var response = new Response<int>();
            var leaveAllocationDto = _mapper.Map<LeaveAllocationDto>(leaveAllocation);
            var apiResponse = await _client.LeaveAllocationPUTAsync(id, leaveAllocationDto);
            if(apiResponse != null)
            {
                response.Success = true;
                response.Data = apiResponse.id;
                response.Message = "Leave Allocation Updated successfully.";
            }
        }
        catch(ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }
}
