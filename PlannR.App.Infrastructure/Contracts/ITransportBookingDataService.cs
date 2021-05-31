using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Transport.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PlannR.App.Infrastructure.Contracts
{
    public interface ITransportBookingDataService : IBaseDataService<EditTransportBookingViewModel, Guid>
    {
        Task<ICollection<TransportBookingListViewModel>> GetAllBookingsAsync();
        Task<EditTransportBookingViewModel> GetBookingByIdAsync(Guid id);
        Task<ICollection<TransportBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId);
    }
}
