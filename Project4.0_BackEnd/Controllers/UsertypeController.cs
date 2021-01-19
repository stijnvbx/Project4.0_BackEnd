using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project4._0_BackEnd.Data;
using Project4._0_BackEnd.Models;

namespace Project4._0_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsertypeController : ControllerBase
    {
        private readonly ApiContext _context;

        public UsertypeController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Usertype
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usertype>>> GetUsertype()
        {
            return await _context.Usertype.ToListAsync();
        }

        // GET: api/Usertype/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usertype>> GetUsertype(int id)
        {
            var usertype = await _context.Usertype.FindAsync(id);

            if (usertype == null)
            {
                return NotFound();
            }

            return usertype;
        }

        // PUT: api/Usertype/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsertype(int id, Usertype usertype)
        {
            if (id != usertype.UsertypeID)
            {
                return BadRequest();
            }

            _context.Entry(usertype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsertypeExists(id))
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

        // POST: api/Usertype
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Usertype>> PostUsertype(Usertype usertype)
        {
            _context.Usertype.Add(usertype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsertype", new { id = usertype.UsertypeID }, usertype);
        }

        // DELETE: api/Usertype/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usertype>> DeleteUsertype(int id)
        {
            var usertype = await _context.Usertype.FindAsync(id);
            if (usertype == null)
            {
                return NotFound();
            }

            _context.Usertype.Remove(usertype);
            await _context.SaveChangesAsync();

            return usertype;
        }

        private bool UsertypeExists(int id)
        {
            return _context.Usertype.Any(e => e.UsertypeID == id);
        }
    }
}
