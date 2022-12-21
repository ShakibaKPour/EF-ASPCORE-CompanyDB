using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTitleController : ControllerBase
    {
        private readonly IDbService _db;

        public EmployeeTitleController(IDbService db)
        {
            _db = db;
        }
        // GET: api/<EmployeeTitleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmployeeTitleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeTitleController>
        [HttpPost]
        //public async Task<IResult> Post([FromBody] EmployeeTitleDTO dto) =>
        //    await _db.HttpPostAsync<EmployeeTitle, EmployeeTitleDTO>(dto);

        // PUT api/<EmployeeTitleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeTitleController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteAsync(EmployeeTitleDTO dto)
            => await _db.HttpDeleteAsync<EmployeeTitle, EmployeeTitleDTO>(dto);
        

    }
}
