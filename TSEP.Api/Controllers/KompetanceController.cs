using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using TSEP.StamData.Application.Kompetance.Commands;
using TSEP.StamData.Application.Kompetance.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TSEP.Api.Controllers
{
    [Route("api/Kompetance")]
    [ApiController]
    public class KompetanceController : ControllerBase
    {
        private readonly IKompetanceCreateCommand _kompetanceCreateCommand;
        private readonly IKompetanceGetQuery _kompetanceGetQuery;
        private readonly IKompetanceGetAllQuery _kompetanceGetAllQuery;
        private readonly IKompetanceEditCommand _kompetanceEditCommand;

        public KompetanceController(
            IKompetanceCreateCommand kompetanceCreateCommand, 
            IKompetanceGetQuery kompetanceGetQuery, 
            IKompetanceGetAllQuery kompetanceGetAllQuery, 
            IKompetanceEditCommand kompetanceEditCommand
            )
        {
            _kompetanceCreateCommand = kompetanceCreateCommand;
            _kompetanceGetQuery = kompetanceGetQuery;
            _kompetanceGetAllQuery = kompetanceGetAllQuery;
            _kompetanceEditCommand = kompetanceEditCommand;
        }

        // GET: api/<OpgaveController>
        [HttpGet]
        public IEnumerable<KompetanceQueryResultDto> Get()
        {
            return _kompetanceGetAllQuery.GetAll();
        }

        // GET api/<OpgaveController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public KompetanceQueryResultDto Get(int id)
        {
            return _kompetanceGetQuery.Get(id);
        }

        // POST api/<OpgaveController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(KompetanceCreateRequestDto request)
        {
            try
            {
                _kompetanceCreateCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<OpgaveController>/5
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(KompetanceEditRequestDto request)
        {
            try
            {
                _kompetanceEditCommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<OpgaveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
