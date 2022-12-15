using System.Data;
using TSEP.Crosscut.TransactionHandling;
using TSEP.Kalender.Application.Booking.Repositories;
using TSEP.Kalender.Domain.DomainServices;
using TSEP.Kalender.Domain.Model;

namespace TSEP.Kalender.Application.Booking.Commands.Implementation
{
    public class BookingCreateCommand : IBookingCreateCommand
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingDomainService _domainService;
        private readonly IUnitOfWork _uow;

        public BookingCreateCommand(IBookingRepository bookingRepository, IBookingDomainService domainService, IUnitOfWork uow)
        {
            _bookingRepository = bookingRepository;
            _domainService = domainService;
            _uow = uow;
        }

        void IBookingCreateCommand.Create(BookingCreateRequestDto bookingCreateRequestDto)
        {
            try
            {
                // kald på UnitOfWork for at sætte isolationsniveau serializable (pessimistisk concurrency) 
                _uow.BeginTransaction(IsolationLevel.Serializable);

                //Opræt Booking med de givne data
                var booking = new BookingEntity(
                    _domainService,
                    bookingCreateRequestDto.StartDate,
                    bookingCreateRequestDto.EndDate,
                    bookingCreateRequestDto.MedarbejderId
                    );

                //Tilføj booking til repository
                _bookingRepository.Add(booking);

                //Gennemfør isolationsniveau
                _uow.Commit();

            }
            //hvis ikke det er muligt throw exception "" og rollback alle ændringer lavet i DB
            catch(Exception e)
            {
                _uow.Rollback();
                throw new Exception(e.Message);
            }

        }
    }
}
