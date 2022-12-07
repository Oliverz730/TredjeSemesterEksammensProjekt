
using System.ComponentModel.DataAnnotations;
using TSEP.Kalender.Domain.DomainServices;

namespace TSEP.Kalender.Domain.Model
{
    public class BookingEntity
    {
        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string MedarbejderId { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        

        private readonly IBookingDomainService _domainService;

        public BookingEntity(IBookingDomainService domainService, int id, DateTime startDate, DateTime endDate, string medarbejderId)
        {

            _domainService = domainService;


            //Pre Conditions
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            MedarbejderId = medarbejderId;

            if (!IsValid()) throw new ArgumentException("Pre-conditions er ikke over holdt");
            if (_domainService.BookingExsistsOnDate(StartDate.Date, EndDate.Date, MedarbejderId)) throw new ArgumentException("Der eksistere allerede en Opgave i den periode");
        }

        protected bool IsValid()
        {
            if(StartDate >= EndDate) return false;

            return true;
        }

        //EF
        internal BookingEntity() {}
    }
}
