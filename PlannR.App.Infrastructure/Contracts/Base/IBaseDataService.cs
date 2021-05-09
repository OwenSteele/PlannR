using Plannr.App.Infrastructure.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Contracts.Base
{
    public interface IBaseDataService<TViewModel> : ICreateBaseDataService<TViewModel> where TViewModel : class
    {
        Task<ApiResponse<Guid>> UpdateAsync(TViewModel viewModel);
        Task<ApiResponse<Guid>> DeleteAsync(Guid bookingId);
    }
}
