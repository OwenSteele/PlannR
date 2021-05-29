using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.ViewModels.Event;
using PlannR.App.Pages.Modals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Event
{
    public partial class EventOverview
    {
        [CascadingParameter]
        public IModalService Modal { get; set; }
        [Inject]
        public IEventDataService EventDataService { get; set; }
        public ICollection<EventListViewModel> Events { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Events = await EventDataService.GetAllEventsAsync();
        }
        private async Task ShowCreateEventModal()
        {
            var modal = Modal.Show<CreateEventModal>("Add a new Event");

            var result = await modal.Result;

            if (!result.Cancelled)
            {
                Events = await EventDataService.GetAllEventsAsync();
                StateHasChanged();
            }
        }
    }
}
