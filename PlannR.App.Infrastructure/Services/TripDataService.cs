using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class TripDataService : BaseDataService, ITripDataService
    {
        private readonly IMapper _mapper;
        public TripDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(TripDetailViewModel viewModel)
        {
            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateTripCommand>(viewModel);

                var result = await _client.AddTripAsync(commandModel);

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
                await _client.DeleteTripAsync(id);

                return new ApiResponse<Guid> { Successful = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<TripListViewModel>> GetAllTripsAsync()
        {
            var result = await _client.GetAllTripsAsync();
            return _mapper.Map<ICollection<TripListViewModel>>(result);
        }

        public async Task<ICollection<TripListBetweenDatesViewModel>> GetAllTripsBetweenDatesAsync(DateTime start, DateTime end)
        {
            var result = await _client.GetAllTripsBetweenDatesAsync(start, end);
            return _mapper.Map<ICollection<TripListBetweenDatesViewModel>>(result);
        }

        public async Task<ICollection<TripListOnDateViewModel>> GetAllTripsOnDateAsync(DateTime date)
        {
            var result = await _client.GetAllTripOnDateAsync(date);
            return _mapper.Map<ICollection<TripListOnDateViewModel>>(result);
        }

        public async Task<TripDetailViewModel> GetTripByIdAsync(Guid id)
        {
            var result = await _client.GetTripByIdAsync(id);
            return _mapper.Map<TripDetailViewModel>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(TripDetailViewModel viewModel)
        {
            try
            {

                var commandModel = _mapper.Map<UpdateTripCommand>(viewModel);

                await _client.UpdateTripAsync(commandModel);

                return new ApiResponse<Guid> { Successful = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}
