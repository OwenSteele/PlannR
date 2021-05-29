using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.Base
{
    public class BookingNestedBaseViewModel
    {
        public Guid BookingId { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
    }
}
