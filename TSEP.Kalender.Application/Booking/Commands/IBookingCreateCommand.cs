
namespace TSEP.Kalender.Application.Booking.Commands
{
    public interface IBookingCreateCommand
    {
        void Create(BookingCreateRequestDto bookingCreateRequestDto);
    }
}
