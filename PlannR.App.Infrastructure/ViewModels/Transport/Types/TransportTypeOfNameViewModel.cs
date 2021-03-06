using System;

namespace PlannR.App.Infrastructure.ViewModels.Transport.Types
{
    public class TransportTypeOfNameViewModel
    {
        public Guid TransportTypeId { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool HasFixedRoute { get; set; }
    }
}