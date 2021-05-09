﻿using AutoMapper;
using Blazored.LocalStorage;
using Plannr.App.Infrastructure.Contracts;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Event.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Services
{
    public class EventTypeDataService : BaseDataService, IEventTypeDataService
    {
        private readonly IMapper _mapper;
        public EventTypeDataService(IMapper mapper, IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public Task<ApiResponse<Guid>> CreateAsync(EventTypeOfNameViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EventTypeListViewModel>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EventTypeOfNameViewModel> GetBookingByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
