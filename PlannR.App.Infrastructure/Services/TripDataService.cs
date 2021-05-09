using AutoMapper;
using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Services
{
    public class TripDataService : BaseDataService, ITripDataService
    {
        private readonly IMapper _mapper;
        public TripDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public Task<ApiResponse<Guid>> CreateAsync(TripDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> DeleteAsync(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TripListViewModel>> GetAllTripAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TripListBetweenDatesViewModel>> GetAllTripBetweenDatesAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TripListOnDateViewModel>> GetAllTripOnDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TripDetailViewModel>> GetTripByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> UpdateAsync(TripDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
