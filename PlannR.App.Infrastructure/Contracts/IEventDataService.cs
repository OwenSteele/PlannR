using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Event;
using PlannR.App.Infrastructure.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface IEventDataService : IBaseDataService<EditEventViewModel, Guid>
    {
        Task<ICollection<EventListViewModel>> GetAllEventsAsync();
        Task<ICollection<EventListOfTripViewModel>> GetAllEventsOfTripIdAsync(Guid tripId);
        Task<ICollection<EventListOnDateViewModel>> GetAllEventsOnDateAsync(DateTime date);
        Task<ICollection<EventListWithBookingsViewModel>> GetAllEventsOfTripWithBookingsAsync(Guid tripId);
        Task<EventDetailViewModel> GetEventByIdAsync(Guid id);
    }
}
