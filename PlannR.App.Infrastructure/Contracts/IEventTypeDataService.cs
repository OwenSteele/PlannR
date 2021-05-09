using Plannr.App.Infrastructure.Contracts.Base;
using Plannr.App.Infrastructure.Services.Base;
using Plannr.App.Infrastructure.ViewModels.Event.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plannr.App.Infrastructure.Contracts
{
    public interface IEventTypeDataService : ICreateBaseDataService<EventTypeOfNameViewModel>
    {
        Task<ICollection<EventTypeListViewModel>> GetAllBookingsAsync();
        Task<EventTypeOfNameViewModel> GetBookingByNameAsync(string name);

    }
}
