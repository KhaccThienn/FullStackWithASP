using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP_WebAPI.Models;

namespace ASP_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<People>>> GetPeoples(string? search)
        {
            if (_context.Peoples == null)
            {
                return NotFound();
            }
            var peoples = await _context.Peoples.ToListAsync();
            if (!string.IsNullOrEmpty(search))
            {
                peoples = await _context.Peoples.Where(x => x.LastName.Contains(search)).ToListAsync();
            }
            return peoples;
        }



        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetPeople(Guid id)
        {
            if (_context.Peoples == null)
            {
                return NotFound();
            }
            var people = await _context.Peoples.FindAsync(id);

            if (people == null)
            {
                return NotFound();
            }

            return people;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeople(Guid id, People people)
        {
            if (id != people.Id)
            {
                return BadRequest();
            }

            _context.Entry(people).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<People>> PostPeople(People people)
        {
            if (_context.Peoples == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Peoples'  is null.");
            }
            _context.Peoples.Add(people);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeople", new { id = people.Id }, people);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeople(Guid id)
        {
            if (_context.Peoples == null)
            {
                return NotFound();
            }
            var people = await _context.Peoples.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            _context.Peoples.Remove(people);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeopleExists(Guid id)
        {
            return (_context.Peoples?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
