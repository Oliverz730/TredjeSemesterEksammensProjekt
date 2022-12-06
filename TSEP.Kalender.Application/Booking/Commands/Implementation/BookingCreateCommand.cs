using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Application.Booking.Repositories;
using TSEP.Kalender.Domain.DomainServices;
using TSEP.Kalender.Domain.Model;

namespace TSEP.Kalender.Application.Booking.Commands.Implementation
{
    public class BookingCreateCommand : IBookingCreateCommand
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingDomainService _domainService;

        public BookingCreateCommand(IBookingRepository bookingRepository, IBookingDomainService domainService)
        {
            _bookingRepository = bookingRepository;
            _domainService = domainService;
        }

        void IBookingCreateCommand.Create(BookingCreateRequestDto bookingCreateRequestDto)
        {
            var booking = new BookingEntity(
                _domainService,
                bookingCreateRequestDto.Id,
                bookingCreateRequestDto.StartDate,
                bookingCreateRequestDto.EndDate,
                bookingCreateRequestDto.MedarbejderId
                );

            _bookingRepository.Add(booking);
        }
    }
}
