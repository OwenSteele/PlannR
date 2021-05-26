using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PlannR.App.Infrastructure.Contracts;
using PlannR.App.Infrastructure.Services.Base;
using PlannR.App.Infrastructure.ViewModels.Locations;
using PlannR.ComponentLibrary.Map;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.App.Pages.Modals
{
    public partial class FullMapModal
    {
        [CascadingParameter]
        public ModalParameters Parameters { get; set; }
        [Parameter]
        public List<Marker> MapPoints { get; set; }

        protected async override Task OnInitializedAsync()
        {
        }
    }
}
