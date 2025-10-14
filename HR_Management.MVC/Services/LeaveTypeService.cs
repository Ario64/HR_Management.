using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services;

public class LeaveTypeService : BaseHttpService, ILeaveTypeService
{
    private readonly IMapper _mapper;

    public LeaveTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
    {
        _mapper = mapper;
    }

    public async Task<Response<int>> CreateLeaveTypeAsync(CreateLeaveTypeViewModel leaveType)
    {
        try
        {
            var response = new Response<int>();
            CreateLeaveTypeDto createLeaveType = _mapper.Map<CreateLeaveTypeDto>(leaveType);
            var apiResponse = await _client.LeaveTypePOSTAsync(createLeaveType);

            //TODO Auth

            if (apiResponse != null)
            {
                response.Data = apiResponse.Id;
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Leave type creation failed.";
                response.Data = 0;
            }

            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }


    }

    public async Task<Response<int>> DeleteLeaveType(int id)
    {
        try
        {
            await _client.LeaveTypeDELETEAsync(id);
            return new Response<int> { Success = true };

            //TODO Auth

        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }

    }

    public async Task<LeaveTypeViewModel> GetLeaveTypeDetailsAsync(int id)
    {
        var leaveType = await _client.LeaveTypeGETAsync(id);
        return _mapper.Map<LeaveTypeViewModel>(leaveType);
    }

    public async Task<List<LeaveTypeViewModel>> GetLeaveTypesAsync()
    {
        var leaveTypes = await _client.LeaveTypeAllAsync();
        return _mapper.Map<List<LeaveTypeViewModel>>(leaveTypes);
    }

    public async Task<Response<int>> UpdateLeaveType(int id, LeaveTypeViewModel leaveType)
    {
        try
        {
            EditLeaveTypeDto leaveTypeDto = _mapper.Map<EditLeaveTypeDto>(leaveType);
            await _client.LeaveTypePUTAsync(id, leaveTypeDto);
            return new Response<int> { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<int>(ex);
        }
    }
}
