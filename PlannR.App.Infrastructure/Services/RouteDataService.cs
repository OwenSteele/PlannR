using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Routes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class RouteDataService : BaseDataService, IRouteDataService
    {
        private readonly IMapper _mapper;
        public RouteDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(EditRouteViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateRouteCommand>(viewModel);

                var result = await _client.AddRouteAsync(commandModel);

                if (result.GetType() == typeof(CreateRouteCommandResponse))
                {
                    response.Data = result.RouteId;
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
                await _client.DeleteRouteAsync(id);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<RouteListViewModel>> GetAllRoutesAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllRoutesAsync();
            return _mapper.Map<ICollection<RouteListViewModel>>(result);
        }

        public async Task<ICollection<RouteListOfTripViewModel>> GetAllRoutesOfTripIdAsync(Guid tripId)
        {
            await AddBearerToken();

            var result = await _client.GetAllRoutesByTripIdAsync(tripId);
            return _mapper.Map<ICollection<RouteListOfTripViewModel>>(result);
        }

        public async Task<ICollection<RouteListOnDateViewModel>> GetAllRoutesOnDateAsync(DateTime date)
        {
            await AddBearerToken();

            var result = await _client.GetAllRouteOnDateAsync(date);
            return _mapper.Map<ICollection<RouteListOnDateViewModel>>(result);
        }

        public async Task<RouteDetailViewModel> GetRouteByIdAsync(Guid id)
        {
            await AddBearerToken();

            var result = await _client.GetRouteByIdAsync(id);
            return _mapper.Map<RouteDetailViewModel>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(EditRouteViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var commandModel = _mapper.Map<UpdateRouteCommand>(viewModel);

                await _client.UpdateRouteAsync(commandModel);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}
