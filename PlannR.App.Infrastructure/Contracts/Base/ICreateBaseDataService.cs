using Plannr.App.Infrastructure.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Contracts.Base
{
    public interface ICreateBaseDataService<TCreateType> where TCreateType : class
    {
        Task<ApiResponse<Guid>> CreateAsync(TCreateType viewModel);
    }
}
