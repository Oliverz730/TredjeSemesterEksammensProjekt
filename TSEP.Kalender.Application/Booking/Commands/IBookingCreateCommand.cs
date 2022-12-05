using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Kalender.Application.Booking.Commands
{
    public interface IBookingCreateCommand
    {
        void Create(BookingCreateRequestDto bookingCreateRequestDto);
    }
}
