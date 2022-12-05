using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        bool IBookingDomainService.BookingExsistsOnDate(DateTime startDate, DateTime endDate)
        {
            return _db.BookingEntities.AsNoTracking().ToList().Any(a => a.StartDate == startDate);
        }
    }
}
