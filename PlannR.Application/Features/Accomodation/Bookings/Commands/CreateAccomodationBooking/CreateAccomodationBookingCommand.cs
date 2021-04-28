﻿using MediatR;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlannR.Application.Features.Accomodations.Bookings.Commands.CreateAccomodationBooking
{
    public class CreateAccomodationBookingCommand : IRequest<Guid>
    {
        public Guid AccomodationId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public ICollection<FileStream> Reservations { get; set; }
        public decimal Cost { get; set; }
    }
}
