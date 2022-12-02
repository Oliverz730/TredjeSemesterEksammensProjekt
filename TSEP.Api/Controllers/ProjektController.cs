using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TSEP.Igangsættelse.Application.Projekt.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TSEP.Api.Controllers
{
    [Route("api/Projekt")]
    [ApiController]
    public class ProjektController : ControllerBase
    {
        private readonly IProjektCreateCommand _projektCreateCommand;
        public ProjektController(IProjektCreateCommand projektCreateCommand)
        {
            _projektCreateCommand = projektCreateCommand;
        }

        // GET: api/<ProjektController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProjektController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
