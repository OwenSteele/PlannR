using AutoMapper;
using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Routes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Services
{
    public class RouteDataService : BaseDataService, IRouteDataService
    {
        private readonly IMapper _mapper;
        public RouteDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public Task<ApiResponse<Guid>> CreateAsync(RouteDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> DeleteAsync(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<RouteListViewModel>> GetAllRoutesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<RouteListOfTripViewModel>> GetAllRoutesOfTripIdAsync(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<RouteListOnDateViewModel>> GetAllRoutesOnDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<RouteDetailViewModel>> GetRouteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> UpdateAsync(RouteDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
