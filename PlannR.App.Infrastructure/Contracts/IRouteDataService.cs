using Plannr.App.Infrastructure.Contracts.Base;
using Plannr.App.Infrastructure.ViewModels.Routes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Contracts
{
    public interface IRouteDataService: IBaseDataService<RouteDetailViewModel>
    {
        Task<ICollection<RouteListViewModel>> GetAllRoutesAsync();
        Task<ICollection<RouteListOfTripViewModel>> GetAllRoutesOfTripIdAsync(Guid tripId);
        Task<ICollection<RouteListOnDateViewModel>> GetAllRoutesOnDateAsync(DateTime date);
        Task<ICollection<RouteDetailViewModel>> GetRouteByIdAsync(Guid id);
    }
}
