using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Application.Booking.Repositories;

namespace TSEP.Kalender.Application.Booking.Query.Implementation
{
    public class BookingGetAllQuery : IBookingGetAllQuery
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingGetAllQuery(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        IEnumerable<BookingQueryResultDto> IBookingGetAllQuery.GetAll()
        {
            return _bookingRepository.GetAll();
        }
    }
}
