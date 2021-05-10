using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class AccomodationBookingDataService : BaseDataService, IAccomodationBookingDataService
    {
        private readonly IMapper _mapper;
        public AccomodationBookingDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(AccomodationBookingDetailViewModel viewModel)
        {
                var response = new ApiResponse<Guid>();
            try
            {

                var commandModel = _mapper.Map<CreateAccomodationBookingCommand>(viewModel);

                var result = await _client.AddAccomodationBookingAsync(commandModel);

                if (result.GetType() == typeof(Guid))
                {
                    var newModel = await _client.GetEventBookingByIdAsync(result);

                    //response.Context;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return response;
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
