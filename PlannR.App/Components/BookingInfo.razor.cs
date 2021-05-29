using Microsoft.AspNetCore.Components;
using PlannR.App.Infrastructure.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Components
{
    public partial class BookingInfo
    {
        [Parameter]
        public BookingNestedBaseViewModel Booking { get; set; }
    }
}
