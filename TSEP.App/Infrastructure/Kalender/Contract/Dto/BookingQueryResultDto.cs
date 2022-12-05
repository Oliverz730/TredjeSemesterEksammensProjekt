namespace TSEP.App.Infrastructure.Kalender.Contract.Dto
{
    public class BookingQueryResultDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
