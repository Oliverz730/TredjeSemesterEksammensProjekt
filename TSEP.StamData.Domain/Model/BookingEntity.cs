
namespace TSEP.StamData.Domain.Model
{
    public class BookingEntity
    {
        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public BookingEntity(int id, DateTime startDate, DateTime endDate)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
        }
        internal BookingEntity() {}
    }
}
