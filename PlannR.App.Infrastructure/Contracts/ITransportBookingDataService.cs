using Plannr.App.Infrastructure.Contracts.Base;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Transport.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Plannr.App.Infrastructure.Contracts
{
    public interface ITransportBookingDataService : IBaseDataService<TransportBookingDetailViewModel>
    {
        Task<ICollection<TransportBookingListViewModel>> GetAllBookingsAsync();
        Task<TransportBookingDetailViewModel> GetBookingByIdAsync(Guid id);
        Task<ICollection<TransportBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId);
    }
}
