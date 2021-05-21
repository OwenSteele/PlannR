using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Event.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class EventBookingDataService : BaseDataService, IEventBookingDataService
    {
        private readonly IMapper _mapper;
        public EventBookingDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(EventBookingDetailViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateEventBookingCommand>(viewModel);

                var result = await _client.AddEventBookingAsync(commandModel);

                if (result.GetType() == typeof(Guid))
                {
                    response.Successful = true;
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
                await _client.DeleteEventBookingAsync(id);

                return new ApiResponse<Guid> { Successful = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<EventBookingListViewModel>> GetAllBookingsAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllEventBookingsAsync();
            return _mapper.Map<ICollection<EventBookingListViewModel>>(result);
        }

        public async Task<ICollection<EventBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId)
        {
            await AddBearerToken();

            var result = await _client.GetAllEventBookingsByTripIdAsync(tripId);
            return _mapper.Map<ICollection<EventBookingOfTripListViewModel>>(result);
        }

        public async Task<EventBookingDetailViewModel> GetBookingByIdAsync(Guid id)
        {
            await AddBearerToken();

            var result = await _client.GetEventBookingByIdAsync(id);
            return _mapper.Map<EventBookingDetailViewModel>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(EventBookingDetailViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var commandModel = _mapper.Map<UpdateEventBookingCommand>(viewModel);

                await _client.UpdateEventBookingAsync(commandModel);

                return new ApiResponse<Guid> { Successful = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}
