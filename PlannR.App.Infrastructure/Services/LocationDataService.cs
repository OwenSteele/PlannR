﻿using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class LocationDataService : BaseDataService, ILocationDataService
    {
        private readonly IMapper _mapper;
        public LocationDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(EditLocationViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateLocationCommand>(viewModel);

                var result = await _client.AddLocationAsync(commandModel);

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
                await _client.DeleteLocationAsync(id);

                return new ApiResponse<Guid> { Successful = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<LocationListViewModel>> GetAllLocationsAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllLocationsAsync();
            return _mapper.Map<ICollection<LocationListViewModel>>(result);
        }

        public async Task<LocationDetailViewModel> GetLocationByIdAsync(Guid id)
        {
            await AddBearerToken();

            var result = await _client.GetLocationByIdAsync(id);
            return _mapper.Map<LocationDetailViewModel>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(EditLocationViewModel viewModel)
        {
            await AddBearerToken();

            try
            {

                var commandModel = _mapper.Map<UpdateLocationCommand>(viewModel);

                await _client.UpdateLocationAsync(commandModel);

                return new ApiResponse<Guid> { Successful = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}