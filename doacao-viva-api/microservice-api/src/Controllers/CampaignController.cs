using DoacaoViva.Application.Interface;
using DoacaoViva.Domain.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoacaoVivaAPI.Controllers {
    [Route("api/[controller]")]
    [Authorize]
    public class CampaignController : ControllerBase {
        private readonly ICampaign _campaign;
        public CampaignController(ICampaign campaign) => _campaign = campaign;

        // GET: api/<CampaignController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campaign>>> Get()
            => await _campaign.GetAllAsync();

        // GET api/<CampaignController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campaign?>> Get(Guid id)
            => (id != Guid.Empty) ? await _campaign.GetById(id) : NotFound();

        // POST api/<CampaignController>
        [HttpPost]
        public async Task<ActionResult<Campaign?>> Post([FromBody] Campaign Campaign)
            => (Campaign != null) ? Ok(await _campaign.Post(Campaign)) : BadRequest();

        // PUT api/<CampaignController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Campaign Campaign) {
            var result = await _campaign.Put(id, Campaign);
            return (result != null) ? NoContent() : BadRequest();
        }

        // DELETE api/<CampaignController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) {
            var result = (id != Guid.Empty) ? await _campaign.GetById(id) : null;
            if (result != null) {
                await _campaign.Delete(result);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
