using Microsoft.AspNetCore.Http;
using PlannR.Application.Contracts.Identity;

namespace PlannR.API.Services
{
    public class LoggedInService : ILoggedInService
    {
        public LoggedInService(IHttpContextAccessor accessor)
        {
            UserId = accessor.HttpContext?.User?.Identity?.Name;
        }

        public string UserId { get; }
    }
}
