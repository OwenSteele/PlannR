using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Domain.Shared
{
    public class BookingFile
    {
        public Guid BookingFileId { get; set; }
        public Guid BookingId { get; set; }
        public byte[] FileBytes { get; set; }
    }
}
