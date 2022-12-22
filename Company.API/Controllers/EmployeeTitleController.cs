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

        // POST api/<EmployeeTitleController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] EmployeeTitleDTO dto) =>
            await _db.HttpAddReferenceAsync<EmployeeTitle, EmployeeTitleDTO>(dto);

        // DELETE api/<EmployeeTitleController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteAsync(EmployeeTitleDTO dto)
            => await _db.HttpDeleteAsync<EmployeeTitle, EmployeeTitleDTO>(dto);
        

    }
}
