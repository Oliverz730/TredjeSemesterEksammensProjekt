using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TSEP.Igangsættelse.Application.OpgaveType.Commands;
using TSEP.Igangsættelse.Application.OpgaveType.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TSEP.Api.Controllers
{
    [Route("api/OpgaveType")]
    [ApiController]
    public class OpgaveTypeController : ControllerBase
    {
        private readonly IOpgaveTypeCreateCommand _opgaveTypeCreateCommand;
        private readonly IOpgaveTypeGetAllQuery _opgaveTypeGetAllQuery;

        public OpgaveTypeController(IOpgaveTypeCreateCommand opgaveTypeCreateCommand, IOpgaveTypeGetAllQuery opgaveTypeGetAllQuery)
        {
            _opgaveTypeCreateCommand = opgaveTypeCreateCommand;
            _opgaveTypeGetAllQuery = opgaveTypeGetAllQuery;
        }

        // GET: api/<OpgaveTypeController>
        [HttpGet]
        public IEnumerable<OpgaveTypeQueryResultDto> Get()
        {
            return _opgaveTypeGetAllQuery.GetAll(); 
        }

        // GET api/<OpgaveTypeController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<OpgaveTypeController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(OpgaveTypeCreateRequestDto request)
        {
            try
            {
                _opgaveTypeCreateCommand.CreateOpgaveType(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<OpgaveTypeController>/5
        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Put(int id)
        {
        }

        // DELETE api/<OpgaveTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
