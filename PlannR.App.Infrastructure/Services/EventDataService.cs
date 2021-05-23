using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Event;
using PlannR.App.Infrastructure.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class EventDataService : BaseDataService, IEventDataService
    {
        private readonly IMapper _mapper;
        public EventDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(EditEventViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateEventCommand>(viewModel);

                var result = await _client.AddEventAsync(commandModel);

                if (result.GetType() == typeof(CreateEventCommandResponse))
                {
                    response.Data = result.EventId;
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
                await _client.DeleteEventAsync(id);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<EventListViewModel>> GetAllEventsAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllEventsAsync();
            return _mapper.Map<ICollection<EventListViewModel>>(result);
        }

        public async Task<ICollection<EventListOfTripViewModel>> GetAllEventsOfTripIdAsync(Guid tripId)
        {
            await AddBearerToken();

            var result = await _client.GetAllEventsByTripIdAsync(tripId);
            return _mapper.Map<ICollection<EventListOfTripViewModel>>(result);
        }

        public async Task<ICollection<EventListWithBookingsViewModel>> GetAllEventsOfTripWithBookingsAsync(Guid tripId)
        {
            await AddBearerToken();

            var result = await _client.GetAllEventBookingsByTripIdAsync(tripId);
            return _mapper.Map<ICollection<EventListWithBookingsViewModel>>(result);
        }

        public async Task<ICollection<EventListOnDateViewModel>> GetAllEventsOnDateAsync(DateTime date)
        {
            await AddBearerToken();

            var result = await _client.GetAllEventsOnDateAsync(date);
            return _mapper.Map<ICollection<EventListOnDateViewModel>>(result);
        }

        public async Task<EventDetailViewModel> GetEventByIdAsync(Guid id)
        {
            await AddBearerToken();

            var result = await _client.GetEventByIdAsync(id);
            return _mapper.Map<EventDetailViewModel>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(EditEventViewModel viewModel)
        {
            try
            {
                var commandModel = _mapper.Map<UpdateEventCommand>(viewModel);

                await _client.UpdateEventAsync(commandModel);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}
