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
            //Return de fundne koobingdto fra repository
            return _bookingRepository.GetAll();
        }
    }
}
