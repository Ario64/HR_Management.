namespace HR_Management.MVC.Services.Base;

public class BaseHttpService
{
    protected readonly LocalStorageService _storageService;
    protected readonly IClient _client;

    public BaseHttpService(IClient client, LocalStorageService storageService)
    {
        _storageService = storageService;
        _client = client;
    }

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
    {
        if (exception.StatusCode == 400)
        {
            return new Response<Guid>
            {
                Message = "Validation errors occured !",
                Success = false
            };
        }
        else if (exception.StatusCode == 404)
        {
            return new Response<Guid>
            {
                Message = "Resource not found !",
                Success = false
            };
        }
        else
        {
            return new Response<Guid>
            {
                Message = "Something went wrong, please try again !",
                Success = false
            };
        }
    }

    protected void AddBearerToken()
    {
        if (_storageService.Exists("token"))
        {
            var token = _storageService.GetStorageValue<string>("token");
            if (!string.IsNullOrEmpty(token))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }
    }

}
