
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IDbService _db;

        public CompanyController(IDbService db)
        {
           _db = db;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<IResult> Get() => 
            await _db.HttpGetAsync<CompanyInfo, CompanyInfoDTO>();

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id) => 
            await _db.HttpGetAsync<CompanyInfo, CompanyInfoDTO>(id);

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] CompanyInfoDTO dto) => 
            await _db.HttpPostAsync<CompanyInfo, CompanyInfoDTO>(dto);

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] CompanyInfoDTO dto) => 
            await _db.HttpPutAsync<CompanyInfo, CompanyInfoDTO>(dto, id);

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id) => 
            await _db.HttpDeleteAsync<CompanyInfo>(id);
    }
}
