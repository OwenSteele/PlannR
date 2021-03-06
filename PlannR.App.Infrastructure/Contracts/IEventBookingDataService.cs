using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Event.Bookings;
using PlannR.App.Infrastructure.ViewModels.Events.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PlannR.App.Infrastructure.Contracts
{
    public interface IEventBookingDataService : IBaseDataService<EditEventBookingViewModel, Guid>
    {
        Task<ICollection<EventBookingListViewModel>> GetAllBookingsAsync();
        Task<EditEventBookingViewModel> GetBookingByIdAsync(Guid id);
        Task<ICollection<EventBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId);
    }
}
