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
    public class BouquetsController : ControllerBase
    {
        private readonly IFloristRepository _repos;
        private readonly CoreDbContext _context;

        public BouquetsController(IFloristRepository repos, CoreDbContext context)
        {
            _repos = repos;
            _context = context;

        }
        // GET: api/Bouquets
        [HttpGet]
        public async Task<IActionResult> GetBouquets()
        {
            return Ok(await _repos.GetBouquets());
        }

        // GET: api/Bouquets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bouquets>> GetBouquet(int id)
        {
            var bouquets = await _repos.GetBouquet(id);

            if (bouquets == null)
            {
                return NotFound();
            }

            return Ok(bouquets);
        }

        // PUT: api/Bouquets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("update")]
        public async Task<IActionResult> UpdateBouquet([FromBody]Bouquets bouquets)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repos.UpdateBouquet(bouquets);
                    return Ok();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BouquetsExists(bouquets.Id))
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

        // POST: api/Bouquets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("add")]
        public async Task<ActionResult<Bouquets>> AddBouquet(Bouquets bouquets)
        {
            var bouquetId = await _repos.AddBouquet(bouquets);

            return CreatedAtAction(nameof(GetBouquet), new { id = bouquetId }, bouquetId);
        }

        // DELETE: api/Bouquets/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Bouquets>> DeleteBouquets(int id)
        {
            await _repos.DeleteBouquet(id);

            return Ok();
        }

        private bool BouquetsExists(int id)
        {
            return _context.Bouquets.Any(e => e.Id == id);
        }
    }
}
