using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace PlannR.App.Pages.Trip.TripComponents.Base
{
    public partial class BaseDetailComponent<T>
    {
        [Parameter]
        public ICollection<T> Models { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public void NavigateTo(string uri)
        {
            NavigationManager.NavigateTo(uri);
        }
    }
}
