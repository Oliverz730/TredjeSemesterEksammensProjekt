using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Application.Booking.Repositories;
using TSEP.Kalender.Domain.Model;

namespace TSEP.Kalender.Application.Booking.Commands.Implementation
{
    public class BookingCreateCommand : IBookingCreateCommand
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingCreateCommand(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        void IBookingCreateCommand.Create(BookingCreateRequestDto bookingCreateRequestDto)
        {

            var booking = new BookingEntity(
                bookingCreateRequestDto.Id,
                bookingCreateRequestDto.StartDate,
                bookingCreateRequestDto.EndDate
                );

            _bookingRepository.Add(booking);

            //var projekt = new ProjektEntity(
            //    projektCreateRequestDto.StartDate,
            //    projektCreateRequestDto.EndDate,
            //    projektCreateRequestDto.EstimatedTime,
            //    projektCreateRequestDto.ActualEstimated,
            //    projektCreateRequestDto.SælgerUserId,
            //    projektCreateRequestDto.KundeUserId,
            //    projektCreateRequestDto.ProjektName
            //    );

            //_projektRepository.Add(projekt);
        }
    }
}
