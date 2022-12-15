using Microsoft.EntityFrameworkCore;
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
            //tilføj bookings til databasen
            _db.BookingEntities.Add(booking);
            // gem ændringer i databasen
            _db.SaveChanges();
        }
        IEnumerable<BookingQueryResultDto> IBookingRepository.GetAll()
        {
            //iterer over listen af booking
            foreach (var projekt in _db.BookingEntities.AsNoTracking().ToList())
            {
                //Konverter fra Entity til BookingQueryResultDto, og yield hver enkeltvis
                yield return new BookingQueryResultDto
                {
                    Id = projekt.Id,
                    StartDate = projekt.StartDate,
                    EndDate = projekt.EndDate,
                    MedarbejderId = projekt.MedarbejderId,
                    RowVersion = projekt.RowVersion,
                };
            }
        }
    }
}
