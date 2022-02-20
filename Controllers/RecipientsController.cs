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
    public class RecipientsController : ControllerBase
    {
        private readonly CoreDbContext _context;
        private readonly IFloristRepository _repos;

        public RecipientsController(IFloristRepository repos, CoreDbContext context)
        {
            _repos = repos;
            _context = context;
        }

        // GET: api/Recipients
        [HttpGet]
        public async Task<IActionResult> GetRecipients()
        {
            return Ok(await _repos.GetRecipients());
        }

        // GET: api/Recipients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipients>> GetRecipient(int id)
        {
            var recipients = await _repos.GetRecipient(id);

            if (recipients == null)
            {
                return NotFound();
            }

            return Ok(recipients);
        }

        // PUT: api/Recipients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRecipient([FromBody]Recipients recipients)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repos.UpdateRecipient(recipients);
                    return Ok();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipientsExists(recipients.Id))
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
        public async Task<ActionResult<Recipients>> AddRecipient(Recipients recipients)
        {
            var recipientId = await _repos.AddRecipient(recipients);

            return CreatedAtAction(nameof(GetRecipient), new { id = recipientId }, recipients);
        }

        // DELETE: api/Recipients/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Recipients>> DeleteRecipients(int id)
        {
            await _repos.DeleteRecipient(id);

            return Ok();
        }

        private bool RecipientsExists(int id)
        {
            return _context.Recipients.Any(e => e.Id == id);
        }
    }
}
