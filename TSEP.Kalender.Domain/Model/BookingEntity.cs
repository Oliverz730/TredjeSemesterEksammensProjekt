
using System.ComponentModel.DataAnnotations;
using TSEP.Kalender.Domain.DomainServices;

namespace TSEP.Kalender.Domain.Model
{
    public class BookingEntity
    {
        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        

        private readonly IBookingDomainService _domainService;
        public BookingEntity(IBookingDomainService domainService, int id, DateTime startDate, DateTime endDate)
        {

            _domainService = domainService;


            //Pre Conditions
            Id = id;
            StartDate = startDate;
            EndDate = endDate;


            if (_domainService.BookingExsistsOnDate(StartDate.Date, EndDate.Date)) throw new ArgumentException("Der eksistere allerede en Opgave i den periode");
        }
        //EF
        internal BookingEntity() {}
    }
}
