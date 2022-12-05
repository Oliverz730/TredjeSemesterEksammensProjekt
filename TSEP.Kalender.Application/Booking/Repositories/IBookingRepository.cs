using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Application.Booking.Query;
using TSEP.Kalender.Domain.Model;

namespace TSEP.Kalender.Application.Booking.Repositories
{
    public interface IBookingRepository
    {
        void Add(BookingEntity booking);
        IEnumerable<BookingQueryResultDto> GetAll();
    }
}
