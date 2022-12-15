
namespace TSEP.Kalender.Application.Booking.Query
{
    public interface IBookingGetAllQuery
    {
        IEnumerable<BookingQueryResultDto> GetAll();
    }
}
