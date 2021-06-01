using AutoMapper;
using Microsoft.AspNetCore.Components.Authorization;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Services
{
    public class RoutePointDataService : BaseDataService, IRoutePointDataService
    {
        private readonly IMapper _mapper;
        public RoutePointDataService(IMapper mapper, IClient client, AuthenticationStateProvider authenticationStateProvider) : base(client, authenticationStateProvider)
        {
            _mapper = mapper;
        }
        public async Task<ApiResponse<ICollection<Guid>>> AddPointRangeAsync(ICollection<EditRoutePointViewModel> viewModel)
        {
            await AddBearerToken();

            try
            {
                var response = new ApiResponse<ICollection<Guid>>();

                var commandModel = _mapper.Map<ICollection<CreateRoutePointCommand>>(viewModel);

                var result = await _client.AddRoutePointRangeAsync(commandModel);

                if (result.GetType() == typeof(CreateRoutePointRangeCommandResponse))
                {
                    response.Data = result.RoutePointIds;
                    response.Success = true;
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<ICollection<Guid>>(ex);
            }
        }
        public async Task<ApiResponse<ICollection<Guid>>> DeletePointRangeAsync(ICollection<Guid> pointIds)
        {
            await AddBearerToken();

            try
            {
                await _client.DeleteRoutePointRangeAsync(pointIds);

                return new ApiResponse<ICollection<Guid>> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiErrors<ICollection<Guid>>(ex);
            }
        }

        public Task<ApiResponse<Guid>> UpdateAsync(EditRoutePointViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<ICollection<Guid>>> CreateAsync(EditRoutePointViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Guid>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
