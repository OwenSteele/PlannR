using System;

namespace PlannR.Domain.Shared
{
    public class BookingFile
    {
        public Guid BookingFileId { get; set; }
        public Guid BookingId { get; set; }
        public byte[] FileBytes { get; set; }
    }
}
