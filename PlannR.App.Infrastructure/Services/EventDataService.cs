using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Event;
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

        public Task<ApiResponse<Guid>> CreateAsync(EventDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> DeleteAsync(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EventListViewModel>> GetAllEventsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EventListOfTripViewModel>> GetAllEventsOfTripIdAsync(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EventListWithBookingsViewModel>> GetAllEventsOfTripWithBookingsAsync(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EventListOnDateViewModel>> GetAllEventsOnDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EventDetailViewModel>> GetEventByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> UpdateAsync(EventDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
