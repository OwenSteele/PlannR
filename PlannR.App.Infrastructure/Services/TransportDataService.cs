using AutoMapper;
using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Transport;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Services
{
    public class TransportDataService : BaseDataService, ITransportDataService
    {
        private readonly IMapper _mapper;
        public TransportDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public Task<ApiResponse<Guid>> CreateAsync(TransportDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> DeleteAsync(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TransportListViewModel>> GetAllTransportAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TransportListOfTripViewModel>> GetAllTransportOfTripIdAsync(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TransportListWithBookingsViewModel>> GetAllTransportOfTripWithBookingsAsync(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TransportListOnDateViewModel>> GetAllTransportOnDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TransportDetailViewModel>> GetTransportByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> UpdateAsync(TransportDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
