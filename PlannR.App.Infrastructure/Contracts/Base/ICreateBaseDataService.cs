using PlannR.App.Infrastructure.Services.Base;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts.Base
{
    public interface ICreateBaseDataService<TCreateType, TResponse> where TCreateType : class
    {
        Task<ApiResponse<TResponse>> CreateAsync(TCreateType viewModel);
    }
}
