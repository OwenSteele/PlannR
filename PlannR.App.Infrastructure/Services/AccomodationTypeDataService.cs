using AutoMapper;
using Blazored.LocalStorage;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Accomodation;
using PlannR.App.Infrastructure.ViewModels.Accomodation.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class AccomodationTypeDataService : BaseDataService, IAccomodationTypeDataService
    {
        private readonly IMapper _mapper;
        public AccomodationTypeDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsync(AccomodationTypeOfNameViewModel viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<Guid>();

                var commandModel = _mapper.Map<CreateAccomodationTypeCommand>(viewModel);

                var result = await _client.AddAccomodationTypeAsync(commandModel);

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

        public async Task<ICollection<AccomodationTypeNestedViewModel>> GetAllTypeNamesAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllAccomodationTypesAsync();
            return _mapper.Map<ICollection<AccomodationTypeNestedViewModel>>(result);
        }

        public async Task<ICollection<AccomodationTypeListViewModel>> GetAllTypesAsync()
        {
            await AddBearerToken();

            var result = await _client.GetAllAccomodationTypesAsync();
            return _mapper.Map<ICollection<AccomodationTypeListViewModel>>(result);
        }

        public async Task<AccomodationTypeOfNameViewModel> GetTypeByNameAsync(string name)
        {
            await AddBearerToken();

            var result = await _client.GetAccomodationTypeByNameAsync(name);
            return _mapper.Map<AccomodationTypeOfNameViewModel>(result);
        }
    }
}
