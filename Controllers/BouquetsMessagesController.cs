using FloristWebsite.Models;
using FloristWebsite.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloristWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BouquetsMessagesController : ControllerBase
    {
        private readonly CoreDbContext _context;
        private readonly IFloristRepository _repos;

        public BouquetsMessagesController(IFloristRepository repos, CoreDbContext context)
        {
            _repos = repos;
            _context = context;
        }
        // GET: api/BouquetsMessages
        [HttpGet]
        public async Task<IActionResult> GetBouquetMessages()
        {
            return Ok(await _repos.GetBouquetMessages());
        }

        // GET: api/BouquetsMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BouquetsMessages>> GetBouquetsMessage(int id)
        {
            var bouquetMessages = await _repos.GetBouquetMessage(id);

            if (bouquetMessages == null)
            {
                return NotFound();
            }

            return Ok(bouquetMessages);
        }

        // PUT: api/BouquetsMessages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("update")]
        public async Task<IActionResult> UpdateBouquetMessage([FromBody] BouquetsMessages bouquetMessages)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repos.UpdateBouquetMessage(bouquetMessages);
                    return Ok();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BouquetMessagesExists(bouquetMessages.Id))
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

        // POST: api/BouquetsMessages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<BouquetsMessages>> AddBouquetMessage(BouquetsMessages bouquetMessages)
        {
            var bouquetMessageId = await _repos.AddBouquetMessage(bouquetMessages);

            return CreatedAtAction(nameof(GetBouquetsMessage), new { id = bouquetMessageId }, bouquetMessages);
        }

        // DELETE: api/BouquetsMessages/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<BouquetsMessages>> DeleteBouquetMessages(int id)
        {
            await _repos.DeleteBouquetMessage(id);

            return Ok();
        }

        private bool BouquetMessagesExists(int id)
        {
            return _context.BouquetsMessages.Any(e => e.Id == id);
        }
    }
}
