using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FloristWebsite.Models;
using FloristWebsite.Repositories;

namespace FloristWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CoreDbContext _context;
        private readonly IFloristRepository _repos;

        public CustomersController(IFloristRepository repos, CoreDbContext context)
        {
            _repos = repos;
            _context = context;
        }

        // GET: api/Recipients
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _repos.GetCustomers());
        }

        // GET: api/Recipients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomer(int id)
        {
            var customers = await _repos.GetCustomer(id);

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        // PUT: api/Recipients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customers customers)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repos.UpdateCustomer(customers);
                    return Ok();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return BadRequest();
        }

        // POST: api/Recipients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<Customers>> AddCustomer(Customers customers)
        {
            var customerId = await _repos.AddCustomer(customers);

            return CreatedAtAction(nameof(GetCustomer), new { id = customerId }, customers);
        }

        // DELETE: api/Recipients/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Customers>> DeleteCustomers(int id)
        {
            await _repos.DeleteCustomer(id);

            return Ok();
        }

        private bool CustomersExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
