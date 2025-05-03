using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeracidataApi.Application.Models.Responses;
using VeracidataApi.Application.Interfaces;
using VeracidataApi.Application.Models.Requests;

namespace VeracidataApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        // POST api/customers
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<long>> Insert([FromBody] CustomerCreateRequest request)
        {
            var id = await _service.InsertAsync(request);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        // GET api/customers
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CustomerListResponse>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        // GET api/customers/{id}
        [HttpGet("{id:long}")]
        [Authorize]
        public async Task<ActionResult<CustomerResponse>> GetById(long id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        // GET api/customers/by-email?email=foo@bar.com
        [HttpGet("by-email")]
        [Authorize]
        public async Task<ActionResult<CustomerResponse>> GetByEmail([FromQuery] string email)
        {
            var customer = await _service.GetByEmailAsync(email);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        // PUT api/customers/{id}
        [HttpPut("{id:long}")]
        [Authorize]
        public async Task<IActionResult> Update(long id, [FromBody] CustomerUpdateRequest request)
        {
            if (id != request.Id) return BadRequest();
            var updated = await _service.UpdateAsync(request);
            return updated > 0 ? NoContent() : NotFound();
        }

        // PATCH api/customers/{id}/active
        [HttpPatch("{id:long}/active")]
        [Authorize]
        public async Task<IActionResult> UpdateActiveStatus(long id, [FromQuery] bool active)
        {
            var updated = await _service.UpdateActiveStatusAsync(id, active);
            return updated > 0 ? NoContent() : NotFound();
        }

        // DELETE api/customers/{id}
        [HttpDelete("{id:long}")]
        [Authorize]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted > 0 ? NoContent() : NotFound();
        }
    }
}
