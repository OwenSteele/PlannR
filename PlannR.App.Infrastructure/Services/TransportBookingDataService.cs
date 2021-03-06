using AutoMapper;
using Microsoft.AspNetCore.Components.Authorization;
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
        public TransportBookingDataService(IMapper mapper, IClient client, AuthenticationStateProvider authenticationStateProvider) : base(client, authenticationStateProvider)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(EditTransportBookingViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateTransportBookingCommand>(viewModel);

                var result = await _client.AddTransportBookingAsync(commandModel);

                if (result.GetType() == typeof(CreateTransportBookingCommandResponse))
                {
                    response.Data = result.BookingId;
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
                await _client.DeleteTransportBookingAsync(id);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<TransportBookingListViewModel>> GetAllBookingsAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllTransportBookingsAsync();
            return _mapper.Map<ICollection<TransportBookingListViewModel>>(result);
        }

        public async Task<ICollection<TransportBookingOfTripListViewModel>> GetAllBookingsOfTripIdAsync(Guid tripId)
        {
            await AddBearerToken();

            var result = await _client.GetAllTransportBookingsByTripIdAsync(tripId);
            return _mapper.Map<ICollection<TransportBookingOfTripListViewModel>>(result);
        }

        public async Task<EditTransportBookingViewModel> GetBookingByIdAsync(Guid id)
        {
            await AddBearerToken();

            var result = await _client.GetTransportBookingByIdAsync(id);
            return _mapper.Map<EditTransportBookingViewModel>(result);
        }

        public async Task<ApiResponse<Guid>> UpdateAsync(EditTransportBookingViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var commandModel = _mapper.Map<UpdateTransportBookingCommand>(viewModel);

                await _client.UpdateTransportBookingAsync(commandModel);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }
    }
}
