
namespace TSEP.Kalender.Application.Booking.Query
{
    public class BookingQueryResultDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MedarbejderId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
