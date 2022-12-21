using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly IDbService _db;

        public TitlesController(IDbService db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IResult> Get() =>
            await _db.HttpGetAsync<Title, TitleDTO>();

        
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id) =>
            await _db.HttpGetAsync<Title, TitleDTO>(id);

       
        [HttpPost]
        public async Task<IResult> Post([FromBody] TitleDTO dto) =>
            await _db.HttpPostAsync<Title, TitleDTO>(dto);

        
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] TitleDTO dto) =>
            await _db.HttpPutAsync<Title, TitleDTO>(dto, id);

        
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id) =>
            await _db.HttpDeleteAsync<Title>(id);
    }
}
