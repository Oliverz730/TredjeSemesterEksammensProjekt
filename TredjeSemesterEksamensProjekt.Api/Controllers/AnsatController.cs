using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TredjeSemesterEksamensProjekt.Api.Controllers
{
    [Route("api/Ansat")]
    [ApiController]
    public class AnsatController : ControllerBase
    {

        // GET: api/<AnsatController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AnsatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AnsatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AnsatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnsatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
