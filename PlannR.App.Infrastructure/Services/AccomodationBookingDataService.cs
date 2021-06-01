using AutoMapper;
using Microsoft.AspNetCore.Components.Authorization;
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
        public AccomodationBookingDataService(IMapper mapper, IClient client, AuthenticationStateProvider authenticationStateProvider) : base(client, authenticationStateProvider)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(EditAccomodationBookingViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateAccomodationBookingCommand>(viewModel);

                var result = await _client.AddAccomodationBookingAsync(commandModel);

                if (result.GetType() == typeof(CreateAccomodationBookingCommandResponse))
                {
                    response.Data = result.BookingId;
                    response.Success = true;
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteAsync(Guid id)
        {
            await AddBearerToken();

            try
            {
                await _client.DeleteAccomodationBookingAsync(id);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<AccomodationBookingListViewModel>> GetAllBookingsAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllAccomodationBookingsAsync();
            return _mapper.Map<ICollection<AccomodationBookingListViewModel>>(result);
        }

        public async Task<ICollection<AccomodationBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId)
        {
            await AddBearerToken();

            var result = await _client.GetAllAccomodationBookingsByTripIdAsync(tripId);
            return _mapper.Map<ICollection<AccomodationBookingOfTripListViewModel>>(result);
        }

        public async Task<EditAccomodationBookingViewModel> GetBookingByIdAsync(Guid id)
        {
            await AddBearerToken();

            var result = await _client.GetAccomodationBookingByIdAsync(id);
            return _mapper.Map<EditAccomodationBookingViewModel>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(EditAccomodationBookingViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var commandModel = _mapper.Map<UpdateAccomodationBookingCommand>(viewModel);

                await _client.UpdateAccomodationBookingAsync(commandModel);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}
