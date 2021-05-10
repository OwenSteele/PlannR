using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Event.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class EventTypeDataService : BaseDataService, IEventTypeDataService
    {
        private readonly IMapper _mapper;
        public EventTypeDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

         public async Task<ApiResponse<Guid>> CreateAsync(EventTypeOfNameViewModel viewModel)
        {
            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateEventTypeCommand>(viewModel);

                var result = await _client.AddEventTypeAsync(commandModel);

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

         public async Task<ICollection<EventTypeListViewModel>> GetAllTypesAsync()
        {
            var result = await _client.GetAllEventTypesAsync();
            return _mapper.Map<ICollection<EventTypeListViewModel>>(result);
        }

         public async Task<EventTypeOfNameViewModel> GetTypeByNameAsync(string name)
        {
            var result = await _client.GetEventTypeByNameAsync(name);
            return _mapper.Map<EventTypeOfNameViewModel>(result);
        }
    }
}
