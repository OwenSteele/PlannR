using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface ILocationDataService : IBaseDataService<EditLocationViewModel>
    {
        Task<ICollection<LocationListViewModel>> GetAllLocationsAsync();
        Task<LocationDetailViewModel> GetLocationByIdAsync(Guid id);
    }
}
