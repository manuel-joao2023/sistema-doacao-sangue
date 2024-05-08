using DoacaoViva.Application.DTOs;
using DoacaoViva.Application.Interface;
using DoacaoViva.Domain.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoacaoVivaAPI.Controllers {
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase {
        private readonly IUsers _usersServices;

        public UsersController(IUsers users) {
            _usersServices = users;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get() 
            => await _usersServices.GetAllAsync();

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users?>> Get(Guid id) 
            => (id == Guid.Empty) ? NotFound() : await _usersServices.GetById(id);

        // POST api/<UsersController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Users?>> Post([FromBody] Users value)
            => (value != null) ? Ok(await _usersServices.Post(value)) : BadRequest();

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponseDTO?>> Login([FromBody] LoginViewModelDTO login) {
            if ((login is null || (string.IsNullOrWhiteSpace(login.Password) && string.IsNullOrWhiteSpace(login.Username)))) return BadRequest();
            var result = await _usersServices.Login(login);
            return result is null ? NotFound() : Ok(result); 
        }
        

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Users value) {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
