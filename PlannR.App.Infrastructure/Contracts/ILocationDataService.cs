using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Locations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface ILocationDataService : IBaseDataService<EditLocationViewModel, Guid>
    {
        Task<ICollection<LocationListViewModel>> GetAllLocationsAsync();
        Task<LocationDetailViewModel> GetLocationByIdAsync(Guid id);
    }
}
