using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Transport.Bookings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class TransportBookingDataService : BaseDataService, ITransportBookingDataService
    {
        private readonly IMapper _mapper;
        public TransportBookingDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(TransportBookingDetailViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateTransportBookingCommand>(viewModel);

                var result = await _client.AddTransportBookingAsync(commandModel);

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
                await _client.DeleteTransportBookingAsync(id);

                return new ApiResponse<Guid> { Successful = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<TransportBookingListViewModel>> GetAllBookingsAsync()
        {
            await AddBearerToken();

            var result =await _client.GetAllTransportBookingsAsync();
            return _mapper.Map<ICollection<TransportBookingListViewModel>>(result);
        }

        public async Task<ICollection<TransportBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId)
        {
            await AddBearerToken();

            var result =await _client.GetAllTransportBookingsByTripIdAsync(tripId);
            return _mapper.Map<ICollection<TransportBookingOfTripListViewModel>>(result);
        }

        public async Task<TransportBookingDetailViewModel> GetBookingByIdAsync(Guid id)
        {
            await AddBearerToken();

            var result =await _client.GetTransportBookingByIdAsync(id);
            return _mapper.Map<TransportBookingDetailViewModel>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(TransportBookingDetailViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var commandModel = _mapper.Map<UpdateTransportBookingCommand>(viewModel);

                await _client.UpdateTransportBookingAsync(commandModel);

                return new ApiResponse<Guid> { Successful = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}
