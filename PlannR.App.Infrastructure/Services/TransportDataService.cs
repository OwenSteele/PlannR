using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Transport;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class TransportDataService : BaseDataService, ITransportDataService
    {
        private readonly IMapper _mapper;
        public TransportDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(EditTransportViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateTransportCommand>(viewModel);

                var result = await _client.AddTransportAsync(commandModel);

                if (result.GetType() == typeof(CreateTransportCommandResponse))
                {
                    response.Data = result.TransportId;
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
                await _client.DeleteTransportAsync(id);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<TransportListViewModel>> GetAllTransportAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllTransportsAsync();
            return _mapper.Map<ICollection<TransportListViewModel>>(result);
        }

        public async Task<ICollection<TransportListOfTripViewModel>> GetAllTransportOfTripIdAsync(Guid tripId)
        {
            await AddBearerToken();

            var result = await _client.GetAllTransportByTripIdAsync(tripId);
            return _mapper.Map<ICollection<TransportListOfTripViewModel>>(result);
        }

        public async Task<ICollection<TransportListWithBookingsViewModel>> GetAllTransportOfTripWithBookingsAsync(Guid tripId)
        {
            await AddBearerToken();

            var result = await _client.GetAllTransportBookingsByTripIdAsync(tripId);
            return _mapper.Map<ICollection<TransportListWithBookingsViewModel>>(result);
        }

        public async Task<ICollection<TransportListOnDateViewModel>> GetAllTransportOnDateAsync(DateTime date)
        {
            await AddBearerToken();

            var result = await _client.GetAllTransportOnDateAsync(date);
            return _mapper.Map<ICollection<TransportListOnDateViewModel>>(result);
        }

        public async Task<TransportDetailViewModel> GetTransportByIdAsync(Guid id)
        {
            await AddBearerToken();

            var result = await _client.GetTransportByIdAsync(id);
            return _mapper.Map<TransportDetailViewModel>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(EditTransportViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var commandModel = _mapper.Map<UpdateTransportCommand>(viewModel);

                await _client.UpdateTransportAsync(commandModel);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}
