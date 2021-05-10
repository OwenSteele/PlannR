﻿using AutoMapper;
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
            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateAccomodationBookingCommand>(viewModel);

                var result = await _client.AddAccomodationBookingAsync(commandModel);

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
            try
            {
                await _client.DeleteAccomodationBookingAsync(id);

                return new ApiResponse<Guid> { Successful = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<AccomodationBookingListViewModel>> GetAllBookingsAsync()
        {
            var result = await _client.GetAllAccomodationBookingsAsync();
            return _mapper.Map<ICollection<AccomodationBookingListViewModel>>(result);
        }

        public async Task<ICollection<AccomodationBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId)
        {
            var result = await _client.GetAllAccomodationBookingsByTripIdAsync(tripId);
            return _mapper.Map<ICollection<AccomodationBookingOfTripListViewModel>>(result);
        }

        public async Task<AccomodationBookingDetailViewModel> GetBookingByIdAsync(Guid id)
        {
            var result = await _client.GetAccomodationBookingByIdAsync(id);
            return _mapper.Map<AccomodationBookingDetailViewModel>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(AccomodationBookingDetailViewModel viewModel)
        {
            try
            {
                var commandModel = _mapper.Map<UpdateAccomodationBookingCommand>(viewModel);

                await _client.UpdateAccomodationBookingAsync(commandModel);

                return new ApiResponse<Guid> { Successful = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}
