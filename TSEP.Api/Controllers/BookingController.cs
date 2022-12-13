using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TSEP.Kalender.Application.Booking.Commands;
using TSEP.Kalender.Application.Booking.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TSEP.Api.Controllers
{
    [Route("api/Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingCreateCommand _bookingCreateCommand;
        private readonly IBookingGetAllQuery _bookingGetAllQuery;
        public BookingController(
            IBookingCreateCommand bookingCreateCommand,
            IBookingGetAllQuery bookingGetAllQuery
            )
        {
            _bookingCreateCommand = bookingCreateCommand;
            _bookingGetAllQuery = bookingGetAllQuery;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public IEnumerable<BookingQueryResultDto> Get()
        {
            return _bookingGetAllQuery.GetAll();
        }
        
        // POST api/<BookingController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(BookingCreateRequestDto request)
        {
            try
            {
                _bookingCreateCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
