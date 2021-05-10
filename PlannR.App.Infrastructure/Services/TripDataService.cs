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
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<Guid>> DeleteAsync(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TripListViewModel>> GetAllTripsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TripListBetweenDatesViewModel>> GetAllTripsBetweenDatesAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TripListOnDateViewModel>> GetAllTripsOnDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<TripDetailViewModel> GetTripByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(TripDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
