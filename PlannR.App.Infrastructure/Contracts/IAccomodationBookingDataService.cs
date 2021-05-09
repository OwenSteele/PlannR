using Plannr.App.Infrastructure.Contracts.Base;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Accomodation.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Contracts
{
    public interface IAccomodationBookingDataService : IBaseDataService<AccomodationBookingDetailViewModel>
    {
        Task<ICollection<AccomodationBookingListViewModel>> GetAllBookingsAsync();
        Task<AccomodationBookingDetailViewModel> GetBookingByIdAsync(Guid id);
        Task<ICollection<AccomodationBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId);
    }
}
