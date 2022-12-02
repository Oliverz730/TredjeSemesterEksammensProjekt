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
        private readonly IKompetanceCreateCommand _createKompetanceCommand;
        private readonly IKompetanceGetQuery _kompetanceGetQuery;
        private readonly IKompetanceGetAllQuery _kompetanceGetAllQuery;

        public KompetanceController(
            IKompetanceCreateCommand createKompetanceCommand,
            IKompetanceGetQuery kompetanceGetQuery,
            IKompetanceGetAllQuery kompetanceGetAllQuery
            )
        {
            _createKompetanceCommand = createKompetanceCommand;
            _kompetanceGetQuery = kompetanceGetQuery;
            _kompetanceGetAllQuery = kompetanceGetAllQuery;
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
                _createKompetanceCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<OpgaveController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] int id)
        {
            try
            {
                //_createKompetanceCommand.Create(request);
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
