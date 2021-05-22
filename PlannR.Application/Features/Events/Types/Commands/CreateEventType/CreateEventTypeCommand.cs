﻿using MediatR;
using System;

namespace PlannR.Application.Features.Events.Types.Commands.CreateEventType
{
    public class CreateEventTypeCommand : IRequest<CreateEventTypeCommandResponse>
    {
        public string Name { get; set; }
    }
}
