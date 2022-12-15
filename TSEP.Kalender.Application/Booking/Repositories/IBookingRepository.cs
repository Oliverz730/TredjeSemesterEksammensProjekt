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
