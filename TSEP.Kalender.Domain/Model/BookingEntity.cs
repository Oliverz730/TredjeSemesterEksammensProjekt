
using System.ComponentModel.DataAnnotations;

namespace TSEP.Kalender.Domain.Model
{
    public class BookingEntity
    {
        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public BookingEntity(int id, DateTime startDate, DateTime endDate)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
        }
        //EF
        internal BookingEntity() {}
    }
}
