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
    public class BoxUserController : ControllerBase
    {
        private readonly ApiContext _context;

        public BoxUserController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/BoxUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoxUser>>> GetBoxUser()
        {
            return await _context.BoxUsers.ToListAsync();
        }

        // GET: api/BoxUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoxUser>> GetBoxUser(int id)
        {
            var BoxUser = await _context.BoxUsers.FindAsync(id);

            if (BoxUser == null)
            {
                return NotFound();
            }

            return BoxUser;
        }

        // PUT: api/BoxUser/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoxUser(int id, BoxUser BoxUser)
        {
            if (id != BoxUser.BoxUserID)
            {
                return BadRequest();
            }

            _context.Entry(BoxUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoxUserExists(id))
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

        // POST: api/BoxUser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BoxUser>> PostBoxUser(BoxUser BoxUser)
        {
            _context.BoxUsers.Add(BoxUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoxUser", new { id = BoxUser.BoxUserID }, BoxUser);
        }

        // DELETE: api/BoxUser/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoxUser>> DeleteBoxUser(int id)
        {
            var BoxUser = await _context.BoxUsers.FindAsync(id);
            if (BoxUser == null)
            {
                return NotFound();
            }

            _context.BoxUsers.Remove(BoxUser);
            await _context.SaveChangesAsync();

            return BoxUser;
        }

        private bool BoxUserExists(int id)
        {
            return _context.BoxUsers.Any(e => e.BoxUserID == id);
        }
    }
}
