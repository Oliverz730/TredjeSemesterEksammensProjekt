using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TredjeSemesterEksamensProjekt.Opgave.Application.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TredjeSemesterEksamensProjekt.Api.Controllers
{
    [Route("api/Opgave")]
    [ApiController]
    public class KompetanceController : ControllerBase
    {
        private readonly IKompetanceCreateCommand _createKompetanceCommand;

        public KompetanceController(IKompetanceCreateCommand createKompetanceCommand)
        {
            _createKompetanceCommand = createKompetanceCommand;
        }

        // GET: api/<OpgaveController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OpgaveController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OpgaveController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
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
