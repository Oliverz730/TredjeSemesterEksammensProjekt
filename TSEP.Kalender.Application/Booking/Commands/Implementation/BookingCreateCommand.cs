using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                _uow.BeginTransaction(IsolationLevel.Serializable);

                var booking = new BookingEntity(
                    _domainService,
                    bookingCreateRequestDto.StartDate,
                    bookingCreateRequestDto.EndDate,
                    bookingCreateRequestDto.MedarbejderId
                    );

                _bookingRepository.Add(booking);

                _uow.Commit();

            }
            catch(Exception e)
            {
                _uow.Rollback();
                throw new Exception(e.Message);
            }

        }
    }
}
