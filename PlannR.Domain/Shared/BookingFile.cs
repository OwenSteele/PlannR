using PlannR.Domain.Common;
using System;

namespace PlannR.Domain.Shared
{
    public class BookingFile : AuditableEntity
    {
        public Guid BookingFileId { get; set; }
        public Guid BookingId { get; set; }
        public byte[] FileBytes { get; set; }
    }
}
