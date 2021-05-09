using AutoMapper;
using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Transport.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Services
{
    public class TransportTypeDataService : BaseDataService, ITransportTypeDataService
    {
        private readonly IMapper _mapper;

        public TransportTypeDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public Task<ApiResponse<Guid>> CreateAsync(TransportTypeOfNameViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TransportTypeListViewModel>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TransportTypeOfNameViewModel> GetBookingByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
