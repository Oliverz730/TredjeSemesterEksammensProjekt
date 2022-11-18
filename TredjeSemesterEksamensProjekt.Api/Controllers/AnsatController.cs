using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TredjeSemesterEksamensProjekt.Opgave.Application.Commands;
using TredjeSemesterEksamensProjekt.Opgave.Application.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TredjeSemesterEksamensProjekt.Api.Controllers
{
    [Route("api/Ansat")]
    [ApiController]
    public class AnsatController : ControllerBase
    {

        private readonly IAnsatCreateCommand _createAnsatCommand;
        private readonly IAnsatGetQuery _getAnsatQuery;
        private readonly IAnsatEditCommand _editAnsatCommand;

        public AnsatController(IAnsatCreateCommand createCommand, IAnsatGetQuery ansatGetQuery, IAnsatEditCommand editAnsatCommand)
        {
            _createAnsatCommand = createCommand;
            _getAnsatQuery = ansatGetQuery;
            _editAnsatCommand = editAnsatCommand;
        }

        // GET: api/<AnsatController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AnsatController>/5
        [HttpGet("{userId}")]
        public AnsatQueryResultDto Get(string userId)
        {
            return _getAnsatQuery.Get(userId);
        }

        // POST api/<AnsatController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(AnsatCreateRequestDto request)
        {

            try
            {
                _createAnsatCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<AnsatController>
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(AnsatEditRequestDto request)
        {
            try
            {
                _editAnsatCommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<AnsatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
