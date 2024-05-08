using DoacaoViva.Application.Interface;
using DoacaoViva.Domain.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoacaoVivaAPI.Controllers {
    [Route("api/[controller]")]
    [Authorize]
    public class RequestsController : ControllerBase {
        private readonly IRequest _request;
        public RequestsController(IRequest request)=> _request = request;
        
        // GET: api/<RequestsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> Get()
            => await _request.GetAllAsync();
          

        // GET api/<RequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request?>> GetById(Guid id) 
            =>(id != Guid.Empty) ? await _request.GetById(id) : NotFound();
           

        // POST api/<RequestsController>
        //[HttpPost]
        //public async Task<ActionResult<Request>> Post([FromBody] Request request)
        //    => (request != null) ? Ok(await _request.Post(request)) : BadRequest();
        [HttpPost(nameof(Solicitacao))]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> Solicitacao([FromBody] Request request)
             => (request != null) ? Ok(await _request.Solicitacao(request)) : BadRequest();

        // PUT api/<RequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Request request) {
            var result = await _request.Put(id, request);
            return (result != null) ? NoContent() : BadRequest();
        }

        // DELETE api/<RequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) {
            var result = (id != Guid.Empty) ? await _request.GetById(id) : null;
            if (result != null) {
                await _request.Delete(result);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
