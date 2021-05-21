using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services.Base
{
    public class BaseDataService
    {

        protected IClient _client;
        protected readonly ILocalStorageService _localStorage;

        public BaseDataService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected static ApiResponse<Guid> ConvertApiErrors<Guid>(ApiException ex)
        {
            return ex.StatusCode switch
            {
                400 => new ApiResponse<Guid>() { Message = "Validation errors have occured.", Errors = ex.Response, Successful = false },
                401 => new ApiResponse<Guid>() { Message = "Access was denied.", Successful = false },
                404 => new ApiResponse<Guid>() { Message = "The requested item could not be found.", Successful = false },
                _ => new ApiResponse<Guid>() { Message = "Something went wrong, please try again.", Successful = false },
            };
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainKeyAsync("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new
                    AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
            }
        }
    }
}
