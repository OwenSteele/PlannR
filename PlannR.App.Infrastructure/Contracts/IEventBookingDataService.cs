using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Event.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PlannR.App.Infrastructure.Contracts
{
    public interface IEventBookingDataService : IBaseDataService<EventBookingDetailViewModel>
    {
        Task<ICollection<EventBookingListViewModel>> GetAllBookingsAsync();
        Task<EventBookingDetailViewModel> GetBookingByIdAsync(Guid id);
        Task<ICollection<EventBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId);
    }
}
