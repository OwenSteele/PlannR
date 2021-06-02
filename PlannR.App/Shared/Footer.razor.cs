using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Shared
{
    public partial class Footer
    {
        [Parameter]
        public string FooterClass { get; set; } = "footer-wrapper";        
    }
}
