using AutoMapper;
using Microsoft.AspNetCore.Components.Authorization;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Nested;
using PlannR.App.Infrastructure.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class TripDataService : BaseDataService, ITripDataService
    {
        private readonly IMapper _mapper;
        public TripDataService(IMapper mapper, IClient client, AuthenticationStateProvider authenticationStateProvider) : base(client, authenticationStateProvider)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(EditTripViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateTripCommand>(viewModel);

                var result = await _client.AddTripAsync(commandModel);

                if (result.GetType() == typeof(CreateTripCommandResponse))
                {
                    response.Data = result.TripId;
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
                await _client.DeleteTripAsync(id);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<TripListViewModel>> GetAllTripsAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllTripsAsync();
            return _mapper.Map<ICollection<TripListViewModel>>(result);
        }
        public async Task<ICollection<TripNestedViewModel>> GetTripNamesAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllTripNamesOnlyAsync();
            return _mapper.Map<ICollection<TripNestedViewModel>>(result);
        }

        public async Task<ICollection<TripListBetweenDatesViewModel>> GetAllTripsBetweenDatesAsync(DateTime start, DateTime end)
        {
            await AddBearerToken();

            var result = await _client.GetAllTripsBetweenDatesAsync(start, end);
            return _mapper.Map<ICollection<TripListBetweenDatesViewModel>>(result);
        }

        public async Task<ICollection<TripListOnDateViewModel>> GetAllTripsOnDateAsync(DateTime date)
        {
            await AddBearerToken();

            var result = await _client.GetAllTripOnDateAsync(date);
            return _mapper.Map<ICollection<TripListOnDateViewModel>>(result);
        }

        public async Task<TripDetailViewModel> GetTripByIdAsync(Guid id)
        {
            await AddBearerToken();

            var result = await _client.GetTripByIdAsync(id);
            return _mapper.Map<TripDetailViewModel>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(EditTripViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var commandModel = _mapper.Map<UpdateTripCommand>(viewModel);

                await _client.UpdateTripAsync(commandModel);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}
