using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface IAccomodationBookingDataService : IBaseDataService<AccomodationBookingDetailViewModel, Guid>
    {
        Task<ICollection<AccomodationBookingListViewModel>> GetAllBookingsAsync();
        Task<AccomodationBookingDetailViewModel> GetBookingByIdAsync(Guid id);
        Task<ICollection<AccomodationBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId);
    }
}
