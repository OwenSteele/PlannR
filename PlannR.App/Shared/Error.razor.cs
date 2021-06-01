using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Shared
{
    public partial class Error
    {
        [Inject]
        ILogger<Error> Logger { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void ProcessError(Exception ex)
        {
            Logger.LogError("Error:ProcessError - Type: {Type} Message: {Message}",
                ex.GetType(), ex.Message);
        }
    }
}
