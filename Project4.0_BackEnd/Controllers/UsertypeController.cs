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
    public class UserTypeController : ControllerBase
    {
        private readonly ApiContext _context;

        public UserTypeController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/UserType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserType>>> GetUserType()
        {
            return await _context.UserTypes.ToListAsync();
        }

        // GET: api/UserType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserType>> GetUserType(int id)
        {
            var UserType = await _context.UserTypes.FindAsync(id);

            if (UserType == null)
            {
                return NotFound();
            }

            return UserType;
        }

        // PUT: api/UserType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserType(int id, UserType UserType)
        {
            if (id != UserType.UserTypeID)
            {
                return BadRequest();
            }

            _context.Entry(UserType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTypeExists(id))
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

        // POST: api/UserType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserType>> PostUserType(UserType UserType)
        {
            _context.UserTypes.Add(UserType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserType", new { id = UserType.UserTypeID }, UserType);
        }

        // DELETE: api/UserType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserType>> DeleteUserType(int id)
        {
            var UserType = await _context.UserTypes.FindAsync(id);
            if (UserType == null)
            {
                return NotFound();
            }

            _context.UserTypes.Remove(UserType);
            await _context.SaveChangesAsync();

            return UserType;
        }

        private bool UserTypeExists(int id)
        {
            return _context.UserTypes.Any(e => e.UserTypeID == id);
        }
    }
}
