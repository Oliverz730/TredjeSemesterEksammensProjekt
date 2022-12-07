namespace TSEP.App.Infrastructure.Kalender.Contract.Dto
{
    public class BookingCreateRequestDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MedarbejderId { get; set; }
    }
}
