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
        private readonly IOpgaveEditCommand _opgaveEditCommand;

        public OpgaveController(
            IOpgaveCreateCommand opgaveCreateCommand,
            IOpgaveGetAllQuery opgaveGetAllQuery, 
            IOpgaveGetQuery opgaveGetQuery, 
            IOpgaveEditCommand opgaveEditCommand
            )
        {
            _opgaveCreateCommand = opgaveCreateCommand;
            _opgaveGetAllQuery = opgaveGetAllQuery;
            _opgaveGetQuery = opgaveGetQuery;
            _opgaveEditCommand = opgaveEditCommand;
        }

        // GET: api/<OpgaveController>
        [HttpGet("{index}/{id}")]
        public IEnumerable<OpgaveQueryResultDto> Get(int index, int id)
        {

            switch (index)
            {
                case 0: //Get By Projekt
                    return _opgaveGetAllQuery.GetAllByProjekt(id);
                    break;

                case 1:
                    return _opgaveGetAllQuery.GetAllByAnsat(id);
                    break;

                default:
                    //WTF
                    throw new Exception("Wrong get all index");
                    break;
            }

        }

        // GET api/<OpgaveController>/5
        [HttpGet("{projektId}/{opgaveTypeId}/{ansatId}")]
        public OpgaveQueryResultDto Get(int projektId,int opgaveTypeId,int ansatId)
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

        // PUT api/<OpgaveController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OpgaveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
