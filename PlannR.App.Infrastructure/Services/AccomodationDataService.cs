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

        public async Task<ApiResponse<Guid>> CreateAsync(EditAccomodationViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateAccomodationCommand>(viewModel);

                var result = await _client.AddAccomodationAsync(commandModel);

                if (result.GetType() == typeof(CreateAccomodationCommandResponse))
                {
                    response.Data = result.AccomodationId;
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
                await _client.DeleteAccomodationAsync(id);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<AccomodationDetailViewModel> GetAccomodationByIdAsync(Guid id)
        {
            await AddBearerToken();

            var result = await _client.GetAccomodationByIdAsync(id);
            return _mapper.Map<AccomodationDetailViewModel>(result);
        }

        public async Task<ICollection<AccomodationListViewModel>> GetAllAccomodationAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllAccomodationsAsync();
            return _mapper.Map<ICollection<AccomodationListViewModel>>(result);
        }

        public async Task<ICollection<AccomodationListOfTripViewModel>> GetAllAccomodationOfTripIdAsync(Guid tripId)
        {
            await AddBearerToken();

            var result = await _client.GetAllAccomodationByTripIdAsync(tripId);
            return _mapper.Map<ICollection<AccomodationListOfTripViewModel>>(result);
        }

        public async Task<ICollection<AccomodationListWithBookingsViewModel>> GetAllAccomodationOfTripWithBookingsAsync(Guid tripId)
        {
            await AddBearerToken();

            var result = await _client.GetAllAccomodationBookingsByTripIdAsync(tripId);
            return _mapper.Map<ICollection<AccomodationListWithBookingsViewModel>>(result);
        }

        public async Task<ICollection<AccomodationListOnDateViewModel>> GetAllAccomodationOnDateAsync(DateTime date)
        {
            await AddBearerToken();

            var result = await _client.GetAllAccomodationOnDateAsync(date);
            return _mapper.Map<ICollection<AccomodationListOnDateViewModel>>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(EditAccomodationViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var commandModel = _mapper.Map<UpdateAccomodationCommand>(viewModel);

                await _client.UpdateAccomodationAsync(commandModel);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}
