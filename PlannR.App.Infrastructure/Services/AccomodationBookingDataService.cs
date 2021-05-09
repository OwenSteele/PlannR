using AutoMapper;
using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Accomodation.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Services
{
    public class AccomodationBookingDataService : BaseDataService, IAccomodationBookingDataService
    {
        private readonly IMapper _mapper;
        public AccomodationBookingDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public Task<ApiResponse<Guid>> CreateAsync(AccomodationBookingDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> DeleteAsync(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AccomodationBookingListViewModel>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AccomodationBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<AccomodationBookingDetailViewModel> GetBookingByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> UpdateAsync(AccomodationBookingDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
