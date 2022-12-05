using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Kalender.Application.Booking.Query
{
    public class BookingQueryResultDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
