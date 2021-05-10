using PlannR.App.Infrastructure.Contracts.Base;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Event.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Contracts
{
    public interface IEventTypeDataService : ICreateBaseDataService<EventTypeOfNameViewModel>
    {
        Task<ICollection<EventTypeListViewModel>> GetAllTypesAsync();
        Task<EventTypeOfNameViewModel> GetTypeByNameAsync(string name);

    }
}
