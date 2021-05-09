using AutoMapper;
using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Transport.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Services
{
    public class TransportBookingDataService : BaseDataService, ITransportBookingDataService
    {
        private readonly IMapper _mapper;
        public TransportBookingDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public Task<ApiResponse<Guid>> CreateAsync(TransportBookingDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> DeleteAsync(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TransportBookingListViewModel>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TransportBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<TransportBookingDetailViewModel> GetBookingByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> UpdateAsync(TransportBookingDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
