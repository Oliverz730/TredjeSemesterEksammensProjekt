
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
        //Hvis Timestamp (RowVersion) tabes under roundtrip, vil man ikke få lov til at edit.
        [Timestamp]
        public byte[] RowVersion { get; set; }
        

        private readonly IBookingDomainService _domainService;

        public BookingEntity(IBookingDomainService domainService, DateTime startDate, DateTime endDate, string medarbejderId)
        {

            _domainService = domainService;


            //Pre Conditions
            StartDate = startDate;
            EndDate = endDate;
            MedarbejderId = medarbejderId;

            if (!IsValid()) throw new ArgumentException("Pre-conditions er ikke over holdt");
            if (_domainService.BookingExsistsOnDate(StartDate, EndDate, MedarbejderId)) throw new ArgumentException("Der eksistere allerede en Opgave i den periode");
        }
        protected bool IsValid()
        {
        //Check for, om startdato er før enddato. hvis ikke return false
            if(StartDate >= EndDate) return false;

            return true;
        }

        //EF
        internal BookingEntity() {}
    }
}
