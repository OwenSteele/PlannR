using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.ViewModels.Transport;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface ITransportDataService : IBaseDataService<EditTransportViewModel, Guid>
    {
        Task<ICollection<TransportListViewModel>> GetAllTransportAsync();
        Task<ICollection<TransportListOfTripViewModel>> GetAllTransportOfTripIdAsync(Guid tripId);
        Task<ICollection<TransportListOnDateViewModel>> GetAllTransportOnDateAsync(DateTime date);
        Task<ICollection<TransportListWithBookingsViewModel>> GetAllTransportOfTripWithBookingsAsync(Guid tripId);
        Task<TransportDetailViewModel> GetTransportByIdAsync(Guid id);
    }
}
