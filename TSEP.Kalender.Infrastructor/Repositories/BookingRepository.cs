using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Application.Booking.Repositories;
using TSEP.Kalender.Domain.Model;
using TSEP.Kalender.Application.Booking.Query;
using TSEP.SqlDbContext;

namespace TSEP.Kalender.Infrastructor.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TredjeSemesterEksamensProjektContext _db;
        public BookingRepository(TredjeSemesterEksamensProjektContext db)
        {
            _db = db;
        }
        void IBookingRepository.Add(BookingEntity booking)
        {
            _db.BookingEntities.Add(booking);
            _db.SaveChanges();
        }
        IEnumerable<BookingQueryResultDto> IBookingRepository.GetAll()
        {
            foreach (var projekt in _db.BookingEntities.AsNoTracking().ToList())
            {
                yield return new BookingQueryResultDto
                {
                    Id = projekt.Id,
                    StartDate = projekt.StartDate,
                    EndDate = projekt.EndDate,
                    RowVersion = projekt.RowVersion,
                };
            }
        }
    }
}
