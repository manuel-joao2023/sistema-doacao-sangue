using DoacaoViva.Application.Interface;
using DoacaoViva.Domain.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoacaoVivaAPI.Controllers {
    [Route("api/[controller]")]
    [Authorize]
    public class SuportsController : ControllerBase {
        private readonly ISuport _suport;
        public SuportsController(ISuport suport)
        {
            _suport = suport;
        }
        // GET: api/<SuportsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suport>>> Get() 
            => await _suport.GetAllAsync();

        // GET api/<SuportsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suport?>> GetById(Guid id) 
            =>(id != Guid.Empty) ? await _suport.GetById(id) : NotFound();
        
        // GET api/<SuportsController>/5
        [HttpGet("GetSuportByParent/{parentId}")]
        public async Task<ActionResult<IEnumerable<Suport?>>> GetSuportByParent(Guid parentId) 
            =>(parentId != Guid.Empty) ? Ok(await _suport.GetSuportByParent(parentId)) : NotFound();
        
        // GET api/<SuportsController>/description
        [HttpGet("GetSuportByDescription/{description}")]
        public async Task<ActionResult<Suport?>> GetSuportByDescription(string description) 
            =>(!string.IsNullOrWhiteSpace(description)) ? await _suport.GetSuportByDescription(description) : NotFound();
        
        // GET api/<SuportsController>/description
        [HttpGet("GetSuportByAbbreviation/{abbreviation}")]
        public async Task<ActionResult<Suport?>> GetSuportByAbbreviation(string abbreviation) 
            =>(!string.IsNullOrWhiteSpace(abbreviation)) ? await _suport.GetSuportByAbbreviation(abbreviation) : NotFound();

        // POST api/<SuportsController>
        [HttpPost]
        public async Task<ActionResult<Suport?>> Post([FromBody] Suport value)
            => (value != null) ? Ok(await _suport.Post(value)) : BadRequest();

        // PUT api/<SuportsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Suport value) {
            var result = await _suport.Put(id, value);
            return (result != null) ? NoContent() : BadRequest();
        }

        // DELETE api/<SuportsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) {
            var result = (id != Guid.Empty) ? await _suport.GetById(id) : null;
            if (result != null) {
                await _suport.Delete(result);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
