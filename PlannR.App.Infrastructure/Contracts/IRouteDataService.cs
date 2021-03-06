using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Routes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface IRouteDataService : IBaseDataService<EditRouteViewModel, Guid>
    {
        Task<ICollection<RouteListViewModel>> GetAllRoutesAsync();
        Task<ICollection<RouteListOfTripViewModel>> GetAllRoutesOfTripIdAsync(Guid tripId);
        Task<ICollection<RouteListOnDateViewModel>> GetAllRoutesOnDateAsync(DateTime date);
        Task<RouteDetailViewModel> GetRouteByIdAsync(Guid id);
    }
}
