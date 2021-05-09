using Plannr.App.Infrastructure.Contracts.Base;
using Plannr.App.Infrastructure.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Contracts
{
    public interface ITripDataService : IBaseDataService<TripDetailViewModel>
    {
        Task<ICollection<TripListViewModel>> GetAllTripAsync();
        Task<ICollection<TripListOnDateViewModel>> GetAllTripOnDateAsync(DateTime date);
        Task<ICollection<TripListBetweenDatesViewModel>> GetAllTripBetweenDatesAsync(DateTime start, DateTime end);
        Task<ICollection<TripDetailViewModel>> GetTripByIdAsync(Guid id);
    }
}
