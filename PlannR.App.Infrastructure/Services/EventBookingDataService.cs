﻿using AutoMapper;
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

        public Task<ApiResponse<Guid>> CreateAsync(EventBookingDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> DeleteAsync(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EventBookingListViewModel>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EventBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<EventBookingDetailViewModel> GetBookingByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> UpdateAsync(EventBookingDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
