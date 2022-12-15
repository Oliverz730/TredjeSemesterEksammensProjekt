using Microsoft.EntityFrameworkCore;
using TSEP.Kalender.Domain.DomainServices;
using TSEP.SqlDbContext;
using Microsoft.EntityFrameworkCore;


namespace TSEP.Kalender.Infrastructor.DomainServices
{
    public class BookingDomainService : IBookingDomainService
    {
        private readonly TredjeSemesterEksamensProjektContext _db;
        public BookingDomainService(TredjeSemesterEksamensProjektContext db)
        {
            _db = db;
        }
        bool IBookingDomainService.BookingExsistsOnDate(DateTime startDate, DateTime endDate, string medarbejderId)
        {
            return _db.BookingEntities.AsNoTracking().ToList().Any(b =>
            startDate < b.EndDate && endDate > b.StartDate
            && b.MedarbejderId == medarbejderId
            );
        }
    }
}
