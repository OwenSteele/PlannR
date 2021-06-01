using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PlannR.App.Infrastructure.Authentication;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services.Base
{
    public class BaseDataService
    {
        protected IClient _client;
        protected readonly AuthenticationStateProvider _authenticationStateProvider;

        public BaseDataService(IClient client, AuthenticationStateProvider authenticationStateProvider)
        {
            _client = client;
            _authenticationStateProvider = authenticationStateProvider;
        }

        protected static ApiResponse<Guid> ConvertApiErrors<Guid>(ApiException ex)
        {
            return ex.StatusCode switch
            {
                400 => new ApiResponse<Guid>() { Message = "Validation errors have occured.", Errors = ex.Response, Success = false },
                401 => new ApiResponse<Guid>() { Message = "Access was denied.", Success = false },
                404 => new ApiResponse<Guid>() { Message = "The requested item could not be found.", Success = false },
                _ => new ApiResponse<Guid>() { Message = "Something went wrong, please try again.", Success = false },
            };
        }

        protected async Task AddBearerToken()
        {
            var plannrAuthenticationStateProvider = (PlannrAuthenticationStateProvider)_authenticationStateProvider;
            var token = await plannrAuthenticationStateProvider.GetTokenAsync();

            if (!string.IsNullOrWhiteSpace(token))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new
                        AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
