using AutoMapper;
using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Accomodation.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Services
{
    public class AccomodationTypeDataService : BaseDataService, IAccomodationTypeDataService
    {
        private readonly IMapper _mapper;
        public AccomodationTypeDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public Task<ApiResponse<Guid>> CreateAsync(AccomodationTypeOfNameViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AccomodationTypeListViewModel>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AccomodationTypeOfNameViewModel> GetBookingByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
