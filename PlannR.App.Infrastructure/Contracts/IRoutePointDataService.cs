using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Routes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface IRoutePointDataService : IBaseDataService<RoutePointNestedViewModel, ICollection<Guid>>
    {
        Task<ApiResponse<ICollection<Guid>>> AddPointRangeAsync(ICollection<RoutePointNestedViewModel> points);
        Task<ApiResponse<ICollection<Guid>>> DeletePointRangeAsync(ICollection<Guid> pointIds);
    }
}
