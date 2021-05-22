using PlannR.App.Infrastructure.Services.Base;
using System;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts.Base
{
    public interface IBaseDataService<TViewModel, TResponse> : ICreateBaseDataService<TViewModel, TResponse> where TViewModel : class
    {
        Task<ApiResponse<Guid>> UpdateAsync(TViewModel viewModel);
        Task<ApiResponse<Guid>> DeleteAsync(Guid id);
    }
}
