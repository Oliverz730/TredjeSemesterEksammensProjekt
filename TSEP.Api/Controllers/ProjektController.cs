using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TSEP.Igangsættelse.Application.Projekt.Commands;
using TSEP.Igangsættelse.Application.Projekt.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TSEP.Api.Controllers
{
    [Route("api/Projekt")]
    [ApiController]
    public class ProjektController : ControllerBase
    {
        private readonly IProjektCreateCommand _projektCreateCommand;
        private readonly IProjektGetQuery _projektGetQuery;
        private readonly IProjektGetAllQuery _projektGetAllQuery;
        public ProjektController(
            IProjektCreateCommand projektCreateCommand,
            IProjektGetAllQuery projektGetAllQuery,
            IProjektGetQuery projektGetQuery
            )
        {
            _projektCreateCommand = projektCreateCommand;
            _projektGetAllQuery = projektGetAllQuery;
            _projektGetQuery = projektGetQuery;
        }

        // GET: api/<ProjektController>
        [HttpGet]
        public IEnumerable<ProjektQueryResultDto> Get(string userId)
        {
            return _projektGetAllQuery.GetAll(userId);
        }

        // GET api/<ProjektController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ProjektQueryResultDto Get(int id)
        {
            return _projektGetQuery.Get(id);
        }

        // POST api/<ProjektController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(ProjektCreateRequestDto request)
        {
            try
            {
                _projektCreateCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ProjektController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProjektController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
