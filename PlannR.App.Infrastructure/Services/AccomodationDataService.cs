using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class AccomodationDataService : BaseDataService, IAccomodationDataService
    {
        private readonly IMapper _mapper;
        public AccomodationDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public Task<ApiResponse<Guid>> CreateAsync(AccomodationDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> DeleteAsync(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AccomodationDetailViewModel>> GetAccomodationByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AccomodationListViewModel>> GetAllAccomodationAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AccomodationListOfTripViewModel>> GetAllAccomodationOfTripIdAsync(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AccomodationListWithBookingsViewModel>> GetAllAccomodationOfTripWithBookingsAsync(Guid tripId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AccomodationListOnDateViewModel>> GetAllAccomodationOnDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> UpdateAsync(AccomodationDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
