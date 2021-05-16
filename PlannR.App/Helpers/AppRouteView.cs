using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using PlannR.App.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Helpers
{
    public class AppRouteView : RouteView
        {
            [Inject]
            public NavigationManager NavigationManager { get; set; }

            [Inject]
            public IAuthenticationDataService AuthenticationDataService { get; set; }

            protected override void Render(RenderTreeBuilder builder)
            {
                var authorize = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute)) != null;
                if (authorize && AuthenticationDataService.IsLoggedInAsync().Result)
                {
                    var returnUrl = WebUtility.UrlEncode(new Uri(NavigationManager.Uri).PathAndQuery);
                    NavigationManager.NavigateTo($"login?returnUrl={returnUrl}");
                }
                else
                {
                    base.Render(builder);
                }
            }
        }
    }
}
