using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Transport.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class TransportTypeDataService : BaseDataService, ITransportTypeDataService
    {
        private readonly IMapper _mapper;

        public TransportTypeDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(TransportTypeOfNameViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateTransportTypeCommand>(viewModel);

                var result = await _client.AddTransportTypeAsync(commandModel);

                if (result.GetType() == typeof(CreateTransportTypeCommandResponse))
                {
                    response.Data = result.TransportTypeId;
                    response.Success = true;
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<Guid>(ex);
            }
        }

        public async Task<ICollection<TransportTypeListViewModel>> GetAllTypesAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllTransportTypesAsync();
            return _mapper.Map<ICollection<TransportTypeListViewModel>>(result);
        }

        public async Task<TransportTypeOfNameViewModel> GetTypeByNameAsync(string name)
        {
            await AddBearerToken();

            var result = await _client.GetTransportTypeByNameAsync(name);
            return _mapper.Map<TransportTypeOfNameViewModel>(result);
        }
    }
}
