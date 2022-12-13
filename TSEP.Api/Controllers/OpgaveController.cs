using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TSEP.Kalender.Application.Opgave.Commands;
using TSEP.Kalender.Application.Opgave.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TSEP.Api.Controllers
{
    [Route("api/Opgave")]
    [ApiController]
    public class OpgaveController : ControllerBase
    {
        private readonly IOpgaveCreateCommand _opgaveCreateCommand;
        private readonly IOpgaveGetAllQuery _opgaveGetAllQuery;
        private readonly IOpgaveGetQuery _opgaveGetQuery;

        public OpgaveController(
            IOpgaveCreateCommand opgaveCreateCommand,
            IOpgaveGetAllQuery opgaveGetAllQuery, 
            IOpgaveGetQuery opgaveGetQuery
            )
        {
            _opgaveCreateCommand = opgaveCreateCommand;
            _opgaveGetAllQuery = opgaveGetAllQuery;
            _opgaveGetQuery = opgaveGetQuery;
        }

        // GET: api/<OpgaveController>
        [HttpGet("Projekt/{id}")]
        public IEnumerable<OpgaveQueryResultDto> GetByProjekt(int id)
        {
            return _opgaveGetAllQuery.GetAllByProjekt(id);
        }

        // GET: api/<OpgaveController>
        [HttpGet("Ansat/{id}")]
        public IEnumerable<OpgaveQueryResultDto> GetByAnsat(string id)
        {
            return _opgaveGetAllQuery.GetAllByAnsat(id);
            
        }

        // GET api/<OpgaveController>/5
        [HttpGet("{projektId}/{opgaveTypeId}/{ansatId}")]
        public OpgaveQueryResultDto Get(int projektId,int opgaveTypeId,string ansatId)
        {
            return _opgaveGetQuery.Get(projektId, opgaveTypeId, ansatId);
        }

        // POST api/<OpgaveController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(OpgaveCreateRequestDto request)
        {
            try
            {
                _opgaveCreateCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
