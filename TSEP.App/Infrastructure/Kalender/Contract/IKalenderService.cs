using TSEP.App.Infrastructure.Kalender.Contract.Dto;

namespace TSEP.App.Infrastructure.Kalender.Contract
{
    public interface IKalenderService
    {
        Task CreateBooking(BookingCreateRequestDto bookingCreateRequestDto);
        Task<IEnumerable<BookingQueryResultDto>?> GetAllBookings();
        Task CreateOpgave(OpgaveCreateRequestDto opgaveCreateRequestDto);

    }
}
