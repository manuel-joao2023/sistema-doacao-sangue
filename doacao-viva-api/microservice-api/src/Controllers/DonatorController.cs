using DoacaoViva.Application.Interface;
using DoacaoViva.Domain.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoacaoVivaAPI.Controllers {
    [Route("api/[controller]")]
    [Authorize]
    public class DonatorController : ControllerBase {
        private readonly IDonator _donator;
        public DonatorController(IDonator donator) => _donator = donator;
        
        // GET: api/<DonatorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donator>>> Get() 
            => await _donator.GetAllAsync();

        // GET api/<DonatorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donator?>> Get(Guid id) 
            => (id != Guid.Empty) ? await _donator.GetById(id) : NotFound();
        // GET api/<DonatorController>/5
        [HttpGet("GetDonatorByAge/{age}")]
        public async Task<ActionResult<IEnumerable<Donator?>>> GetDonatorByAge(int age) 
            => (age > 17) ? Ok(await _donator.GetDonatorByAge(age)) : NotFound();
        // GET api/<DonatorController>/5
        [HttpGet("GetDonatorByIdBloobType/{IdBloodType}")]
        public async Task<ActionResult<IEnumerable<Donator?>>> GetDonatorByIdBloobType(Guid IdBloodType) 
            => (IdBloodType != Guid.Empty) ? Ok(await _donator.GetDonatorByIdBloobType(IdBloodType)) : NotFound();
        
        // GET api/<DonatorController>/5
        [HttpGet("GetDonatorByIdHospital/{IdHospital}")]
        public async Task<ActionResult<IEnumerable<Donator?>>> GetDonatorByIdHospital(Guid IdHospital) 
            => (IdHospital != Guid.Empty) ? Ok(await _donator.GetDonatorByIdHospital(IdHospital)) : NotFound(); 
        // GET api/<DonatorController>/5
        [HttpGet("GetDonatorByIdPerson/{IdPerson}")]
        public async Task<ActionResult<IEnumerable<Donator?>>> GetDonatorByIdPerson(Guid IdPerson) 
            => (IdPerson != Guid.Empty) ? Ok(await _donator.GetDonatorByIdPerson(IdPerson)) : NotFound();

        // POST api/<DonatorController>
        [HttpPost]
        public async Task<ActionResult<Donator?>> Post([FromBody] Donator donator) 
            => (donator != null) ? Ok(await _donator.Post(donator)) : BadRequest();

        // PUT api/<DonatorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Donator donator) {
            var result = await _donator.Put(id, donator);
            return (result != null) ? NoContent() : BadRequest();
        }

        // DELETE api/<DonatorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) {
            var result = (id != Guid.Empty) ? await _donator.GetById(id) : null;
            if (result != null) {
                await _donator.Delete(result);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
