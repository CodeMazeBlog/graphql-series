using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly OwnerConsumer _consumer;

        public ValuesController(OwnerConsumer consumer)
        {
            _consumer = consumer;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var owners = await _consumer.GetAllOwners();
            return Ok(owners);
        }

        // GET api/values
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var owner = await _consumer.GetOwner(id);
            return Ok(owner);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OwnerInput owner)
        {
            var createdOwner = await _consumer.CreateOwner(owner);
            return Ok(createdOwner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]OwnerInput owner)
        {
            var updatedOwner = await _consumer.UpdateOwner(id, owner);
            return Ok(updatedOwner);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Put(Guid id)
        {
            var deleteOwner = await _consumer.DeleteOwner(id);
            return Ok(deleteOwner);
        }
    }
}
