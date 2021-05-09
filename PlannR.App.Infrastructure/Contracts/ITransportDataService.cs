using Plannr.App.Infrastructure.Contracts.Base;
using Plannr.App.Infrastructure.ViewModels.Transport;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Contracts
{
    public interface ITransportDataService : IBaseDataService<TransportDetailViewModel>
    {
        Task<ICollection<TransportListViewModel>> GetAllTransportAsync();
        Task<ICollection<TransportListOfTripViewModel>> GetAllTransportOfTripIdAsync(Guid tripId);
        Task<ICollection<TransportListOnDateViewModel>> GetAllTransportOnDateAsync(DateTime date);
        Task<ICollection<TransportListWithBookingsViewModel>> GetAllTransportOfTripWithBookingsAsync(Guid tripId);
        Task<ICollection<TransportDetailViewModel>> GetTransportByIdAsync(Guid id);
    }
}
